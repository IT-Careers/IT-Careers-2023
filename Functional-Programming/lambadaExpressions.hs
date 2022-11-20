import StringUtils;
import HaskeLinq;
import PredefinedFunctions;

getSelectorObjectStartIndex lambadaExpression = (indexOfString lambadaExpression " => ") + 4
getSelectorObjectEndIndex lambadaExpression = indexOfString lambadaExpression "."
getSelectorObject lambadaExpression = subString lambadaExpression (getSelectorObjectStartIndex lambadaExpression) ((getSelectorObjectEndIndex lambadaExpression) - (getSelectorObjectStartIndex lambadaExpression))

getBeforeSelectorObject lambadaExpression = subString lambadaExpression 0 (getSelectorObjectStartIndex lambadaExpression)
getAfterSelectorObject lambadaExpression = subString lambadaExpression (getSelectorObjectEndIndex lambadaExpression) ((length lambadaExpression) - (getSelectorObjectEndIndex lambadaExpression))

danceLambadaExpression lambadaExpression = 
    getBeforeSelectorObject lambadaExpression ++ 
    getSelectorObject lambadaExpression ++ 
    "." ++ 
    getSelectorObject lambadaExpression ++ 
    getAfterSelectorObject lambadaExpression

dance collection = 
    mapList danceLambadaExpression collection

printAll collection = 
    if null collection
        then do 
            return ()
    else do
        putStrLn (head collection)
        printAll (tail collection)

process collection = do
    currentLine <- getLine
    if currentLine == "lambada"
        then do 
            printAll collection
            return ()
    else if currentLine == "dance"
        then do
            process (dance collection)
    else do
        process (collection ++ [currentLine])

main = do
    process []