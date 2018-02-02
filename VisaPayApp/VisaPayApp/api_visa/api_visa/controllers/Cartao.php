<?php
namespace controllers{
	/*
	 Classe cartao
	 */
	class Cartao{
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
		
		public function lista($pessoaId){
			global $app;
			$sth = $this->PDO->prepare("SELECT * FROM cartao WHERE PessoaId = :pessoaId");
			$sth ->bindValue(':pessoaId',$pessoaId);
			$sth->execute();
			$result = $sth->fetchAll(\PDO::FETCH_ASSOC);
			$app->render('default.php',["data"=>$result],200);
		}
		
		public function get($id){
			global $app;
			$sth = $this->PDO->prepare("SELECT * FROM cartao WHERE id = :id");
			$sth ->bindValue(':id',$id);
			$sth->execute();
			$result = $sth->fetch(\PDO::FETCH_ASSOC);
			$app->render('default.php',["data"=>$result],200);
		}
		
		public function novo(){
			global $app;
			$dados = json_decode($app->request->getBody(), true);
			$dados = (sizeof($dados)==0)? $_POST : $dados;
			unset($dados["Id"]);
			unset($dados["id"]);
			unset($dados["ID"]);
			unset($dados["iD"]);
			$keys = array_keys($dados); //Paga as chaves do array
			/*
			 O uso de prepare e bindValue é importante para se evitar SQL Injection
			 */
			$sth = $this->PDO->prepare("INSERT INTO cartao (".implode(',', $keys).") VALUES (:".implode(",:", $keys).")");
			foreach ($dados as $key => $value) {
				
				if($key == "Numero"){
					$value = preg_replace("/[^0-9]/", "", $value);
				}
				
				$sth ->bindValue(':'.$key, $value);
			}
			
			$idResp = 0;
			try {
				$sth->execute();
				$idResp = $this->PDO->lastInsertId();
			} catch (PDOException $Exception ) {
				$idResp = 0;
			}
			
			
			if($idResp != 0){
				$flErro = false;
				$msg = "";
			}else{
				$flErro = true;
				$msg = "Erro ao cadastra cartão, verifique se o mesmo já esta cadastrado.";
			}
			
			$data = [
					"id" => $idResp,
					"erro" => $flErro,
					"msg" => $msg
			];
			
			//Retorna o id inserido
			$app->render('default.php',["data"=>$data],200);
		}
		
		
	}
	
}