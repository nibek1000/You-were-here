<?php

$connect = mysqli_connect("localhost", "x", "y", "z");

if($connect === false){
  die("ERROR: Could not connect. " . mysqli_connect_error());
}


$sql = "SELECT * FROM `texts`";

$result = $connect->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    echo $row["cordx"]. "#" . $row["cordy"]. "#" . $row["cordz"]."#" . $row["text"]. "%";
  }
} else {
  echo "0 results";
}

?>