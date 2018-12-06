<?php
	$host = "localhost";
	$db = 'id6778179_gacha';
	$user = 'id6778179_admin';
	$pass = 'admin';
	$charset = 'utf8mb4';

	$dsn = "mysql:host=$host;dbname=$db;charset=$charset";
	$opt = [
	    PDO::ATTR_ERRMODE            => PDO::ERRMODE_EXCEPTION,
	    PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,
	    PDO::ATTR_EMULATE_PREPARES   => false,
	];

	$pdo = new PDO($dsn, $user, $pass, $opt);

	$stmt = $pdo->query('SELECT * FROM Heroes');
	while ($row = $stmt->fetch()){
		echo(
		'userId:'.$row['userId'].'|'.
		'heroId:'.$row['heroId'].'|'.
		'heroName:'.$row['heroName'].'|'.
		'heroAtk:'.$row['heroAtk'].'|'.
		'heroDef:'.$row['heroDef'].'|'.
		'heroHp:'.$row['heroHp'].'|'.
		'heroSpd:'.$row['heroSpd']."~");
	}
?>