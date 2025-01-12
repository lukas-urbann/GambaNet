<?php
header("Access-Control-Allow-Origin: *");

$servername = "innodb.endora.cz:3306";
$username = "gambagame";
$password = "GambaNet123";
$dbname = "gambabase";

$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error)
{
    die("500");
}

$request_type = $_POST["requestType"];  
$user_id = $_POST["userId"];  
$game_id = $_POST["gameId"];  
$new_value = $_POST["newValue"];  

$rowName = "NULL";
$sql = "NULL";

switch ($request_type)
{
    case "UserBalanceDownload":
        $sql = "SELECT * FROM aspnetusers WHERE Id = $user_id";
        $rowName = "Balance";
    break;
    case "UserBalanceUpload":
        $sql = "UPDATE aspnetusers SET Balance = $new_value WHERE Id = $user_id";
    break;
    case "GameDataWinrateDownload":
        $sql = "SELECT * FROM game WHERE Id = $game_id";
        $rowName = "Winrate";
    break;
    case "GameDataNameDownload":
        $sql = "SELECT * FROM game WHERE Id = $game_id";
        $rowName = "Name";
    break;
    case "GameDataColorRedDownload":
        $sql = "SELECT * FROM game WHERE Id = $game_id";
        $rowName = "BackgroundRed";
    break;
    case "GameDataColorBlueDownload":
        $sql = "SELECT * FROM game WHERE Id = $game_id";
        $rowName = "BackgroundBlue";
    break;
    case "GameDataColorGreenDownload":
        $sql = "SELECT * FROM game WHERE Id = $game_id";
        $rowName = "BackgroundGreen";
    break;
    default:
        echo "Invalid request type";
        $conn->close();
        return;
}

$result = $conn->query($sql);

if ($rowName == "NULL")
{
    echo "200";
    $conn->close();
    return;
}

if ($result->num_rows > 0)
{
    while($row = $result->fetch_assoc())
    {
        echo $row[$rowName];
    }
}
else
{
    echo "404";
}

$conn->close();