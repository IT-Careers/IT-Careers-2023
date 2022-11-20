module PredefinedFunctions where

for i conditionFunction incrementFunction bodyFunction = do
    if conditionFunction i
        then do
            bodyFunction i
            for (incrementFunction i) conditionFunction incrementFunction bodyFunction
    else return ();

readUntil command process = do
    currentLine <- getLine
    if currentLine == command
        then do 
            return ()
    else do
        process currentLine
        readUntil command process

parseInt x = read x :: Int