# Market-Data-Downloader
Application to Download historical market data from Yahoo

This is an application that will download market data from yahoo. It is designed to download the information on a collection of symbols. The Symbols are listed in the MarketSymbols.txt file in the application's directory. You can specify the directory that will be used to cache the files in the app.config file. 

This was designed to help you get data for use when doing financial analysis in R.
The following code will transform the data into a xts object

getAllPrices <-  function(symbol){
  path <- paste("d:\\StockPriceHistory\\" , symbol, ".csv", sep="")
  df <-read.csv(path,header=TRUE,stringsAsFactors=FALSE)
  dateColumn <-as.Date(df[["Date"]], "%Y-%m-%d")
  df$Date <-NULL

 names(df)[names(df) == "High"]<- paste(symbol, ".High",sep="");
 names(df)[names(df) == "Low"]<- paste(symbol, ".Low",sep="");
 names(df)[names(df) == "Open"]<- paste(symbol, ".Open",sep="");
 names(df)[names(df) == "Close"]<- paste(symbol, ".Close",sep="");
 names(df)[names(df) == "Volume"]<- paste(symbol, ".Volume",sep="");
 names(df)[names(df) == "Adj.Close"]<- paste(symbol, ".Adjusted",sep="");
 as.xts(df, order.by=dateColumn)
}

getPrices<-function (symbol , from, to){
  allPrices <-getAllPrices(symbol)
  selector <- paste(from, "/", to, sep="")
  allPrices[paste(selector)]
} 
