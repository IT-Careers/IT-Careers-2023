module StringUtils where

repeatStr str n =
    if n == 0
        then ""
    else str ++ repeatStr str (n - 1)

-- TODO: Split by string not by character
splitStr' str delimiter currentString result = 
    if length str == 0
        then if length currentString > 0
            then result ++ [currentString]
            else result
    else if [head str] == delimiter
        then splitStr' (tail str) delimiter "" (result ++ [currentString]) 
    else splitStr' (tail str) delimiter (currentString ++ [head str]) result

splitStr str delimiter = splitStr' str delimiter "" []

