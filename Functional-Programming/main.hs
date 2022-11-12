import StringUtils;
import HaskeLinq;
import PredefinedFunctions;

processCommand command = do
    let params = splitStr command " "
    print $ reverseList params

main = do
    readUntil "end" processCommand