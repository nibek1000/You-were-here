<?php

$connect = mysqli_connect("localhost", "x", "y", "z");


if($connect === false){
  die("ERROR: Could not connect. " . mysqli_connect_error());
}

$urlPath = $_SERVER["REQUEST_URI"];

$cordx = array_slice(explode('/', rtrim($urlPath, '/')), -1)[0];
$cordy = array_slice(explode('/', rtrim($urlPath, '/')), -2)[0];
$cordz = array_slice(explode('/', rtrim($urlPath, '/')), -3)[0];
$text = array_slice(explode('/', rtrim($urlPath, '/')), -4)[0];

$sql = "INSERT INTO `texts` (`cordx`, `cordy`, `cordz`, `text`) VALUES ('$cordx', '$cordy', '$cordz', '$text')";
if(mysqli_query($connect, $sql)){
    echo "Records added successfully.";
} else{
    echo "ERROR: Could not able to execute $sql. " . mysqli_error($connect);
}

?>