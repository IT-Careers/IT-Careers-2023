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

swapElements' firstIndex secondIndex list = 
    (take firstIndex list) 
    ++ ([get list secondIndex]) 
    ++ (take ((secondIndex - firstIndex - 1)) (drop (firstIndex + 1) list)) 
    ++ ([get list firstIndex])
    ++ (drop (secondIndex + 1) list)

swapElements firstIndex secondIndex list = 
    if firstIndex > secondIndex 
        then swapElements' secondIndex firstIndex list
    else swapElements' firstIndex secondIndex list

reduce reducerFunc accumulator list = 
    if null list
        then accumulator
    else reduce reducerFunc (reducerFunc accumulator (head list)) (tail list)

generate' n = [n] ++ generate' (n + 1) 

generate = generate' 1

insertOrderedElement' ordererFunc list element =
    if null list
        then [element]
    else if ordererFunc element < ordererFunc (head list)
        then [element] ++ list
    else [head list] ++ insertOrderedElement' ordererFunc (tail list) element

orderBy' ordererFunc list resultList =
    if null list
        then resultList
    else orderBy' ordererFunc (tail list) (insertOrderedElement' ordererFunc resultList (head list))

orderBy ordererFunc list = orderBy' ordererFunc list []

insertOrderedElementDesdending' ordererFunc list element =
    if null list
        then [element]
    else if ordererFunc element > ordererFunc (head list)
        then [element] ++ list
    else [head list] ++ insertOrderedElementDesdending' ordererFunc (tail list) element

orderByDescending' ordererFunc list resultList =
    if null list
        then resultList
    else orderByDescending' ordererFunc (tail list) (insertOrderedElementDesdending' ordererFunc resultList (head list))

orderByDescending ordererFunc list = orderByDescending' ordererFunc list []

insertOrderedElementDesdendingThenBy' ordererFunc thenByFunc list element =
    if null list
        then [element]
    else if ordererFunc element > ordererFunc (head list)
        then [element] ++ list
    else if ordererFunc element == ordererFunc (head list) && (thenByFunc element) > (thenByFunc (head list))
        then [element] ++ list
    else [head list] ++ insertOrderedElementDesdendingThenBy' ordererFunc thenByFunc (tail list) element

orderByDescendingThenBy' ordererFunc thenByFunc list resultList =
    if null list
        then resultList
    else orderByDescendingThenBy' ordererFunc thenByFunc (tail list) (insertOrderedElementDesdendingThenBy' ordererFunc thenByFunc resultList (head list))

orderByDescendingThenBy ordererFunc thenByFunc list = orderByDescendingThenBy' ordererFunc thenByFunc list []

-- contains

contains element list =
    if null list
        then False
    else if (head list) == element
        then True
    else contains element (tail list)

distinct list =
    if null list
        then []
    else if contains (head list) (tail list)
        then distinct (tail list)
    else [head list] ++ distinct (tail list)

-- TUPLE UTILS

getKey (key, _) = key
getValue (_, value) = value
