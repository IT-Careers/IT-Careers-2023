import StringUtils;
import HaskeLinq;
import PredefinedFunctions;
import Text.Read;

printAll collection = 
    if null collection
        then do 
            return ()
    else do
        putStrLn (head collection)
        printAll (tail collection)

parseCollectionWithMethods collectionWithMethods = 
    [(head (splitStr collectionWithMethods "."))]
    ++ mapList (\x -> subString x 0 ((length x) - 2)) (tail (splitStr collectionWithMethods "."))

addKeyValuePair key value collection = 
    if null collection
        then [(key, value)]
    else if (getKey (head collection)) == key
        then [(getKey (head collection), distinct (getValue (head collection) ++ value))] ++ (tail collection)
    else [head collection] ++ addKeyValuePair key value (tail collection)

getByKey key collection = 
    if null collection 
        then ("", [])
    else if getKey (head collection) == key
        then head collection
    else getByKey key (tail collection)

isInteger input = (readMaybe input :: Maybe Int) /= Nothing

processAdding currentLine collection = addKeyValuePair (head (parseCollectionWithMethods currentLine)) (tail (parseCollectionWithMethods currentLine)) collection

process collection = do
    currentLine <- getLine
    if currentLine == "exit"
        then do 
            lastLine <- getLine
            let commandParams = splitStr lastLine " "
            let method = head commandParams
            let choice = head (tail commandParams)
            let filteredCollection = filterList (\x -> contains method (getValue x)) collection
            if choice == "all"
                then do
                    print "blah"
                else do
                    printAll (map getKey filteredCollection)
            return ()
    else if (null (tail (parseCollectionWithMethods currentLine))) 
        && (not (isInteger currentLine)) 
        && (contains currentLine (map getKey collection))
        then do
            printAll (map (\x -> "* " ++ x) (orderByDescendingThenBy (\x -> (length x)) (\x -> (length (distinct x))) (getValue (getByKey currentLine collection))))
            process collection
    else if (null (tail (parseCollectionWithMethods currentLine))) 
        && (isInteger currentLine)
        then do
            printAll (map (\x -> "* " ++ x) (take (parseInt currentLine) (orderBy (\x -> length x) (getValue (head (orderByDescending (\x -> length (getValue x)) collection))))))
            process collection
    else do
        process (processAdding currentLine collection)

main = do
    process []
    