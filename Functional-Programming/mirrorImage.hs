import StringUtils;
import HaskeLinq;
import PredefinedFunctions;

cutPartition currentIndex targetIndex collection = 
    take (targetIndex - currentIndex) (drop currentIndex collection)

processCommand index collection = 
    (reverseList (cutPartition 0 index collection)) ++ [get collection index] ++ (reverseList (cutPartition (index + 1) (length collection) collection))

process collection = do
    currentLine <- getLine
    if currentLine == "Print"
        then do 
            print collection
            return ()
    else do
        let index = parseInt currentLine
        process (processCommand index collection)

main = do
    input <- getLine
    let collection = splitStr input " "
    process collection