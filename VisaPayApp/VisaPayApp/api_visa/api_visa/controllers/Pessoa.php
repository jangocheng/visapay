<?php
namespace controllers{
	/*
	Classe pessoa
	*/
	class Pessoa{
		//Atributo para banco de dados
		private $PDO;

		/*
		__construct
		Conectando ao banco de dados
		*/
		function __construct(){
			$this->PDO = new \PDO('mysql:host=localhost;dbname=visa_teste', 'root', ''); //Conexão
			//$this->PDO->setAttribute( \PDO::ATTR_ERRMODE,\PDO::ERRMODE_EXCEPTION ); //habilitando erros do PDO
			$this->PDO->exec("set names utf8");
		}
		/*
		lista
		Listand pessoas
		*/
		public function lista(){
			global $app;
			$sth = $this->PDO->prepare("SELECT * FROM pessoa");
			$sth->execute();
			$result = $sth->fetchAll(\PDO::FETCH_ASSOC);
			$app->render('default.php',["data"=>$result],200); 
		}
		/*
		get
		param $id
		Pega pessoa pelo id
		*/
		public function get($id){
			global $app;
			$sth = $this->PDO->prepare("SELECT * FROM pessoa WHERE id = :id");
			$sth ->bindValue(':id',$id);
			$sth->execute();
			$result = $sth->fetch(\PDO::FETCH_ASSOC);
			$app->render('default.php',["data"=>$result],200); 
		}

		public function login(){
			global $app;
			$dados = json_decode($app->request->getBody(), true);
			$dados = (sizeof($dados)==0)? $_POST : $dados;
			
			$sth = $this->PDO->prepare("SELECT * FROM pessoa WHERE Email = :email and Senha = :senha ");
			
			$sth->bindValue(':email',$dados['Email']);
			$sth->bindValue(':senha', md5($dados['Senha']));
			
			$sth->execute();
			$result = $sth->fetchAll(\PDO::FETCH_ASSOC);
			$app->render('default.php',["data"=>$result],200); 
			
		}
		
		
		/*
		nova
		Cadastra pessoa
		*/
		public function nova(){
			global $app;
			$dados = json_decode($app->request->getBody(), true);
			$dados = (sizeof($dados)==0)? $_POST : $dados;
			$keys = array_keys($dados); //Paga as chaves do array
			/*
			O uso de prepare e bindValue é importante para se evitar SQL Injection
			*/
			$sth = $this->PDO->prepare("INSERT INTO pessoa (".implode(',', $keys).") VALUES (:".implode(",:", $keys).")");
			foreach ($dados as $key => $value) {
				
				if($key == "Senha"){
					$value = md5($value);
				}
				
				$sth->bindValue(':'.$key,$value);
			}
			
			$idResp = 0;
			try {
				$sth->execute();
				$idResp = $this->PDO->lastInsertId();
			} catch (PDOException $Exception ) {
				$idResp = 0;
			}
			
			//Retorna o id inserido
			$app->render('default.php',["data"=>['id'=>$idResp]],200); 
		}

		/*
		editar
		param $id
		Editando pessoa
		*/
		public function editar($id){
			global $app;
			$dados = json_decode($app->request->getBody(), true);
			$dados = (sizeof($dados)==0)? $_POST : $dados;
			$sets = [];
			foreach ($dados as $key => $VALUES) {
				$sets[] = $key." = :".$key;
			}

			$sth = $this->PDO->prepare("UPDATE pessoa SET ".implode(',', $sets)." WHERE id = :id");
			$sth ->bindValue(':id',$id);
			foreach ($dados as $key => $value) {
				$sth ->bindValue(':'.$key,$value);
			}
			//Retorna status da edição
			$app->render('default.php',["data"=>['status'=>$sth->execute()==1]],200); 
		}

		/*
		excluir
		param $id
		Excluindo pessoa
		*/
		public function excluir($id){
			global $app;
			$sth = $this->PDO->prepare("DELETE FROM pessoa WHERE id = :id");
			$sth ->bindValue(':id',$id);
			$app->render('default.php',["data"=>['status'=>$sth->execute()==1]],200); 
		}
	}
}