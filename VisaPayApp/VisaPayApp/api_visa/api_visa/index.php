<?php
//Autoload
$loader = require 'vendor/autoload.php';

//Instanciando objeto
$app = new \Slim\Slim(array(
    'templates.path' => 'templates'
));

//Listando todas
// $app->get('/pessoas/', function() use ($app){
// 	(new \controllers\Pessoa($app))->lista();
// });

//get pessoa
$app->get('/pessoa/:id', function($id) use ($app){
	(new \controllers\Pessoa($app))->get($id);
});

//nova pessoa
$app->post('/pessoa/', function() use ($app){
	(new \controllers\Pessoa($app))->nova();
});

//edita pessoa
$app->put('/pessoas/:id', function($id) use ($app){
	(new \controllers\Pessoa($app))->editar($id);
});

$app->post('/login/', function() use ($app){
	(new \controllers\Pessoa($app))->login();
});

//apaga pessoa
// $app->delete('/pessoas/:id', function($id) use ($app){
// 	(new \controllers\Pessoa($app))->excluir($id);
// });

/*********** METODOS DE CARTAO *************/

//Listando todas
	$app->get('/cartoes/:pessoaId', function($pessoaId) use ($app){
		(new \controllers\Cartao($app))->lista($pessoaId);
});

$app->get('/cartao/:id', function($id) use ($app){
	(new \controllers\Cartao($app))->get($id);
});

//novo cartão
$app->post('/cartao/', function() use ($app){
	(new \controllers\Cartao($app))->novo();
});

/*********** METODOS DE TRANSAÇÕES *************/
// $app->post('/pagamento/', function() use ($app){
// 	(new \controllers\Transacao($app))->pagamento();
// });

/*********** METODOS DE DISPOSITIVOS *************/
$app->post('/dispositivo/', function() use ($app){
	(new \controllers\Dispositivo($app))->novo();
});

$app->get('/dispositivos/:pessoaId', function($pessoaId) use ($app){
	(new \controllers\Dispositivo($app))->lista($pessoaId);
});

$app->get('/dispositivo/:id', function($id) use ($app){
	(new \controllers\Dispositivo($app))->get($id);
});

/****************************************************/
	$app->post('/pagamento/', function() use ($app){
		(new \controllers\MoIPController($app))->pagamento();
	});



//Rodando aplicação
$app->run();