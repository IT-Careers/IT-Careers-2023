module HaskeLinq where

reverseList' list result n = 
    if length result == n
        then result
    else reverseList' (tail list) ([(head list)] ++ result) n

reverseList list = reverseList' list [] (length list) 

