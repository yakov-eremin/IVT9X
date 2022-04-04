<?php

        $data = file_get_contents('php://input');
        //Encode the array into a JSON string.
        $encodedString = json_encode($data);
        
        //Save the JSON string to a text file.
        file_put_contents('settings.txt', $encodedString);
    
     
?>