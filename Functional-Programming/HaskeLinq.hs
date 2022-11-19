module HaskeLinq where

reverseList' list result n = 
    if length result == n
        then result
    else reverseList' (tail list) ([(head list)] ++ result) n

reverseList list = reverseList' list [] (length list) 

mapList mappingFunc list = 
    if null list
        then []
    else [mappingFunc $ head list] ++ (mapList mappingFunc (tail list))

filterList filterFunc list =
    if null list
        then []
    else if not (filterFunc (head list))
        then filterList filterFunc (tail list)
    else [head list] ++ filterList filterFunc (tail list)

enumerate start end =
    if start > end
        then []
    else [start] ++ enumerate (start + 1) end

get list index = 
    if index == 0
        then (head list)
    else get (tail list) (index - 1)

reduce reducerFunc accumulator list = 
    if null list
        then accumulator
    else reduce reducerFunc (reducerFunc accumulator (head list)) (tail list)

generate' n = [n] ++ generate' (n + 1) 

generate = generate' 1