module StringUtils where

repeatStr str n =
    if n == 0
        then ""
    else str ++ repeatStr str (n - 1)

indexOfString' currentIndex str substr = 
    if currentIndex > ((length str) - (length substr))
        then -1
    else if (take (length substr) (drop currentIndex str)) == substr
        then currentIndex
    else indexOfString' (currentIndex + 1) str substr

indexOfString str substr = 
    if length substr > length str 
        then -1
    else if str == substr
        then 0
    else indexOfString' 0 str substr

subString str start len = take len (drop start str)

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