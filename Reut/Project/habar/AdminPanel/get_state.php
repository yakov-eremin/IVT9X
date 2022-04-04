<?php
    //Retrieve the data from our text file.
    $fileContents = file_get_contents('settings.txt');
    //Convert the JSON string back into an array.
    $decoded = json_decode($fileContents, true);
    
    echo  json_encode($decoded)   ;
?>