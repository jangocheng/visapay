<?php
namespace controllers{
	class Transacao{
		
		function __construct(){
			$this->PDO = new \PDO('mysql:host=localhost;dbname=visa_teste', 'root', ''); //Conexão
			//$this->PDO->setAttribute( \PDO::ATTR_ERRMODE,\PDO::ERRMODE_EXCEPTION ); //habilitando erros do PDO
			$this->PDO->exec("set names utf8");
		}
		
		
		/* POST 
		 * 	valor
		 * 	origem
		 * 	destino
		 * */
		public function pagamento(){
			global $app;
			$dados = json_decode($app->request->getBody(), true);
			$dados = (sizeof($dados)==0)? $_POST : $dados;
			
			$valor = $dados["valor"];
			
			
			$resp = [
					"id" => 1234,
					"erro" => false,
					"valor" => $valor,
					"msg" => "Pagamento efetivado com sucesso."
			];
			
			$app->render('default.php',["data"=>$resp],200);
		}
	}
}