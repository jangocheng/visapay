<?php
namespace controllers{
	class Dispositivo{
		
		function __construct(){
			$this->PDO = new \PDO('mysql:host=localhost;dbname=visa_teste', 'root', ''); //Conexão
			//$this->PDO->setAttribute( \PDO::ATTR_ERRMODE,\PDO::ERRMODE_EXCEPTION ); //habilitando erros do PDO
			$this->PDO->exec("set names utf8");
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
			
			$sth = $this->PDO->prepare("INSERT INTO dispositivo (".implode(',', $keys).") VALUES (:".implode(",:", $keys).")");
			foreach ($dados as $key => $value) {
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
				$msg = "Erro ao cadastra dispositivo, verifique se o mesmo já esta cadastrado.";
			}
			
			$data = [
					"id" => $idResp,
					"erro" => $flErro,
					"msg" => $msg
			];
			
			//Retorna o id inserido
			$app->render('default.php',["data"=>$data],200);
			
		}
	
		public function lista($pessoa){
			global $app;
			$sth = $this->PDO->prepare("SELECT * FROM dispositivo WHERE PessoaId = :pessoaId");
			$sth ->bindValue(':pessoaId',$pessoa);
			$sth->execute();
			$result = $sth->fetchAll(\PDO::FETCH_ASSOC);
			$app->render('default.php',["data"=>$result],200);
		}
		
		public function get($id){
			global $app;
			$sth = $this->PDO->prepare("SELECT * FROM dispositivo WHERE id = :id");
			$sth ->bindValue(':id',$id);
			$sth->execute();
			$result = $sth->fetch(\PDO::FETCH_ASSOC);
			$app->render('default.php',["data"=>$result],200);
		}
	}
}