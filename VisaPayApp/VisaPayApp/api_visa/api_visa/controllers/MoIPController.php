<?php

namespace controllers{
	class MoIPController{
		
		public function pagamento(){
			global $app;
			
			$dados = json_decode($app->request->getBody(), true);
			$dados = (sizeof($dados)==0)? $_POST : $dados;
			
			$xml = "<EnviarInstrucao>
				    <InstrucaoUnica>
				        <Razao>".$dados['Razao']."</Razao>
				        <IdProprio>".$dados['IdProprio']."</IdProprio>
				        <Valores>
				            <Valor moeda='BRL'>".$dados['Valor']."</Valor>
				        </Valores>
					    </InstrucaoUnica>
					</EnviarInstrucao>";
			
			$resposta = $this->enviaInstrucao('BWDMZGBVT03AFWROPHOSJ4QTBPWR9BZX:IYFMXIRV83H08VNZTWAN6OBP7KW6FYQDWFNBMXHW',$xml);
			
			$xml = simplexml_load_string($resposta['resposta']);
			
			$json = json_encode($xml);
			$array = json_decode($json,TRUE);
			
			$app->render('default.php',["data"=>$array['Resposta']],200);
		}
		
		
		
		private function enviaInstrucao($auth,$xml)
		{
			$url =
			'https://desenvolvedor.moip.com.br/sandbox/ws/alpha/EnviarInstrucao/Unica';
			$header[] = "Authorization: Basic " . base64_encode($auth);
			$curl = curl_init();
			curl_setopt($curl, CURLOPT_URL,$url);
			curl_setopt($curl, CURLOPT_HTTPHEADER, $header);
			curl_setopt($curl, CURLOPT_USERPWD, $auth);
			curl_setopt($curl, CURLOPT_SSL_VERIFYPEER, false);
			curl_setopt($curl, CURLOPT_USERAGENT, "Mozilla/4.0");
			curl_setopt($curl, CURLOPT_POST, true);
			curl_setopt($curl, CURLOPT_POSTFIELDS, $xml);
			curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
			$ret = curl_exec($curl);
			$err = curl_error($curl);
			curl_close($curl);
			return array('resposta'=>$ret,'erro'=>$err);
		}
		
		
		
	}
}