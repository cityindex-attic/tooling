﻿using System;
using System.Collections.Generic;
using CityIndex.JsonClient;
using CIAPI.DTO;
namespace CIAPI.Rpc
{
    public partial class Client
    {
        // ***********************************
        // LogOn
        // ***********************************

        /// <summary>
        /// <p>Create a new session. This is how you "log on" to the CIAPI. Post a <a onclick="dojo.hash('#type.ApiLogOnRequestDTO'); return false;" class="json-link" href="#">ApiLogOnRequestDTO</a> to the uri specified below</p>
        /// </summary>
        /// <param name="apiLogOnRequest"> [DESCRIPTION MISSING]</param>
        public ApiLogOnResponseDTO LogOn(ApiLogOnRequestDTO apiLogOnRequest)
        {
            return Request<ApiLogOnResponseDTO>("session", "/", "POST",
            new Dictionary<string, object>
            {
                { "apiLogOnRequest", apiLogOnRequest}
            }, TimeSpan.FromMilliseconds(0), "data");
        }

        /// <summary>
        /// <p>Create a new session. This is how you "log on" to the CIAPI. Post a <a onclick="dojo.hash('#type.ApiLogOnRequestDTO'); return false;" class="json-link" href="#">ApiLogOnRequestDTO</a> to the uri specified below</p>
        /// </summary>
        /// <param name="apiLogOnRequest"> [DESCRIPTION MISSING]</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginLogOn(ApiLogOnRequestDTO apiLogOnRequest, ApiAsyncCallback<ApiLogOnResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "session", "/", "POST",
            new Dictionary<string, object>
            {
                { "apiLogOnRequest", apiLogOnRequest}
            }, TimeSpan.FromMilliseconds(0), "data");
        }

        public ApiLogOnResponseDTO EndLogOn(ApiAsyncResult<ApiLogOnResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // DeleteSession
        // ***********************************

        /// <summary>
        /// <p>Delete a session. This is how you "log off" from the CIAPI.</p>
        /// </summary>
        /// <param name="userName">Username is case sensitive. May be set as a service parameter or as a request header.</param>
        /// <param name="session">The session token. May be set as a service parameter or as a request header.</param>
        public ApiLogOffResponseDTO DeleteSession(string userName, string session)
        {
            return Request<ApiLogOffResponseDTO>("session", "/deleteSession?userName={userName}&session={session}", "POST",
            new Dictionary<string, object>
            {
                { "userName", userName}, 
                { "session", session}
            }, TimeSpan.FromMilliseconds(0), "data");
        }

        /// <summary>
        /// <p>Delete a session. This is how you "log off" from the CIAPI.</p>
        /// </summary>
        /// <param name="userName">Username is case sensitive. May be set as a service parameter or as a request header.</param>
        /// <param name="session">The session token. May be set as a service parameter or as a request header.</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginDeleteSession(string userName, string session, ApiAsyncCallback<ApiLogOffResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "session", "/deleteSession?userName={userName}&session={session}", "POST",
            new Dictionary<string, object>
            {
                { "userName", userName}, 
                { "session", session}
            }, TimeSpan.FromMilliseconds(0), "data");
        }

        public ApiLogOffResponseDTO EndDeleteSession(ApiAsyncResult<ApiLogOffResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // GetPriceBars
        // ***********************************

        /// <summary>
        /// Get historic price bars in OHLC (open, high, low, close) format, suitable for plotting candlestick chartsReturns price bars in ascending order up to the current time.When there are no prices per a particular time period, no price bar is returned. Thus, it can appear that the array of price bars has "gaps", i.e. the gap between the datetime of each price bar might not be equal to interval x spanSample Urls: /market/1234/history?interval=MINUTE&span=15&pricebars=180/market/735/history?interval=HOUR&span=1&pricebars=240/market/1577/history?interval=DAY&span=1&pricebars=10
        /// </summary>
        /// <param name="marketId">The marketId</param>
        /// <param name="interval">The pricebar interval</param>
        /// <param name="span">The number of each interval per pricebar.</param>
        /// <param name="priceBars">The total number of pricebars to return</param>
        public GetPriceBarResponseDTO GetPriceBars(string marketId, string interval, int span, string priceBars)
        {
            return Request<GetPriceBarResponseDTO>("market", "/{marketId}/barhistory?interval={interval}&span={span}&pricebars={priceBars}", "GET",
            new Dictionary<string, object>
            {
                { "marketId", marketId}, 
                { "interval", interval}, 
                { "span", span}, 
                { "priceBars", priceBars}
            }, TimeSpan.FromMilliseconds(10000), "data");
        }

        /// <summary>
        /// Get historic price bars in OHLC (open, high, low, close) format, suitable for plotting candlestick chartsReturns price bars in ascending order up to the current time.When there are no prices per a particular time period, no price bar is returned. Thus, it can appear that the array of price bars has "gaps", i.e. the gap between the datetime of each price bar might not be equal to interval x spanSample Urls: /market/1234/history?interval=MINUTE&span=15&pricebars=180/market/735/history?interval=HOUR&span=1&pricebars=240/market/1577/history?interval=DAY&span=1&pricebars=10
        /// </summary>
        /// <param name="marketId">The marketId</param>
        /// <param name="interval">The pricebar interval</param>
        /// <param name="span">The number of each interval per pricebar.</param>
        /// <param name="priceBars">The total number of pricebars to return</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginGetPriceBars(string marketId, string interval, int span, string priceBars, ApiAsyncCallback<GetPriceBarResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "market", "/{marketId}/barhistory?interval={interval}&span={span}&pricebars={priceBars}", "GET",
            new Dictionary<string, object>
            {
                { "marketId", marketId}, 
                { "interval", interval}, 
                { "span", span}, 
                { "priceBars", priceBars}
            }, TimeSpan.FromMilliseconds(10000), "data");
        }

        public GetPriceBarResponseDTO EndGetPriceBars(ApiAsyncResult<GetPriceBarResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // GetPriceTicks
        // ***********************************

        /// <summary>
        /// Get historic price ticks. Returns price ticks in ascending order up to the current time. The length of time between each tick will be different.
        /// </summary>
        /// <param name="marketId">The marketId</param>
        /// <param name="priceTicks">The total number of price ticks to return</param>
        public GetPriceTickResponseDTO GetPriceTicks(string marketId, string priceTicks)
        {
            return Request<GetPriceTickResponseDTO>("market", "/{marketId}/tickhistory?priceticks={priceTicks}", "GET",
            new Dictionary<string, object>
            {
                { "marketId", marketId}, 
                { "priceTicks", priceTicks}
            }, TimeSpan.FromMilliseconds(10000), "data");
        }

        /// <summary>
        /// Get historic price ticks. Returns price ticks in ascending order up to the current time. The length of time between each tick will be different.
        /// </summary>
        /// <param name="marketId">The marketId</param>
        /// <param name="priceTicks">The total number of price ticks to return</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginGetPriceTicks(string marketId, string priceTicks, ApiAsyncCallback<GetPriceTickResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "market", "/{marketId}/tickhistory?priceticks={priceTicks}", "GET",
            new Dictionary<string, object>
            {
                { "marketId", marketId}, 
                { "priceTicks", priceTicks}
            }, TimeSpan.FromMilliseconds(10000), "data");
        }

        public GetPriceTickResponseDTO EndGetPriceTicks(ApiAsyncResult<GetPriceTickResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // GetMarketInformation
        // ***********************************

        /// <summary>
        /// <p>Get Market Information for the specified market.</p>
        /// </summary>
        /// <param name="marketId">The marketId</param>
        public GetMarketInformationResponseDTO GetMarketInformation(string marketId)
        {
            return Request<GetMarketInformationResponseDTO>("market", "/{marketId}/information", "GET",
            new Dictionary<string, object>
            {
                { "marketId", marketId}
            }, TimeSpan.FromMilliseconds(0), "data");
        }

        /// <summary>
        /// <p>Get Market Information for the specified market.</p>
        /// </summary>
        /// <param name="marketId">The marketId</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginGetMarketInformation(string marketId, ApiAsyncCallback<GetMarketInformationResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "market", "/{marketId}/information", "GET",
            new Dictionary<string, object>
            {
                { "marketId", marketId}
            }, TimeSpan.FromMilliseconds(0), "data");
        }

        public GetMarketInformationResponseDTO EndGetMarketInformation(ApiAsyncResult<GetMarketInformationResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // ListMarketInformationSearch
        // ***********************************

        /// <summary>
        /// <p>Queries for market information.</p>
        /// </summary>
        /// <param name="searchByMarketCode">Should the search be done by market code</param>
        /// <param name="searchByMarketName">Should the search be done by market Name</param>
        /// <param name="spreadProductType">Should the search include spread bet markets</param>
        /// <param name="cfdProductType">Should the search include CFD markets</param>
        /// <param name="binaryProductType">Should the search include binary markets</param>
        /// <param name="query">The text to search for.  Matches part of market name / code from the start.</param>
        /// <param name="maxResults">The maximum number of results to return</param>
        public ListMarketInformationSearchResponseDTO ListMarketInformationSearch(bool searchByMarketCode, bool searchByMarketName, bool spreadProductType, bool cfdProductType, bool binaryProductType, string query, int maxResults)
        {
            return Request<ListMarketInformationSearchResponseDTO>("market", "/informationsearch?SearchByMarketCode={searchByMarketCode}&SearchByMarketName={searchByMarketName}&SpreadProductType={spreadProductType}&CfdProductType={cfdProductType}&BinaryProductType={binaryProductType}&Query={query}&MaxResults={maxResults}", "GET",
            new Dictionary<string, object>
            {
                { "searchByMarketCode", searchByMarketCode}, 
                { "searchByMarketName", searchByMarketName}, 
                { "spreadProductType", spreadProductType}, 
                { "cfdProductType", cfdProductType}, 
                { "binaryProductType", binaryProductType}, 
                { "query", query}, 
                { "maxResults", maxResults}
            }, TimeSpan.FromMilliseconds(0), "data");
        }

        /// <summary>
        /// <p>Queries for market information.</p>
        /// </summary>
        /// <param name="searchByMarketCode">Should the search be done by market code</param>
        /// <param name="searchByMarketName">Should the search be done by market Name</param>
        /// <param name="spreadProductType">Should the search include spread bet markets</param>
        /// <param name="cfdProductType">Should the search include CFD markets</param>
        /// <param name="binaryProductType">Should the search include binary markets</param>
        /// <param name="query">The text to search for.  Matches part of market name / code from the start.</param>
        /// <param name="maxResults">The maximum number of results to return</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginListMarketInformationSearch(bool searchByMarketCode, bool searchByMarketName, bool spreadProductType, bool cfdProductType, bool binaryProductType, string query, int maxResults, ApiAsyncCallback<ListMarketInformationSearchResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "market", "/informationsearch?SearchByMarketCode={searchByMarketCode}&SearchByMarketName={searchByMarketName}&SpreadProductType={spreadProductType}&CfdProductType={cfdProductType}&BinaryProductType={binaryProductType}&Query={query}&MaxResults={maxResults}", "GET",
            new Dictionary<string, object>
            {
                { "searchByMarketCode", searchByMarketCode}, 
                { "searchByMarketName", searchByMarketName}, 
                { "spreadProductType", spreadProductType}, 
                { "cfdProductType", cfdProductType}, 
                { "binaryProductType", binaryProductType}, 
                { "query", query}, 
                { "maxResults", maxResults}
            }, TimeSpan.FromMilliseconds(0), "data");
        }

        public ListMarketInformationSearchResponseDTO EndListMarketInformationSearch(ApiAsyncResult<ListMarketInformationSearchResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // ListNewsHeadlines
        // ***********************************

        /// <summary>
        /// Get a list of current news headlines
        /// </summary>
        /// <param name="category">Filter headlines by category</param>
        /// <param name="maxResults">Restrict the number of headlines returned</param>
        public ListNewsHeadlinesResponseDTO ListNewsHeadlines(string category, int maxResults)
        {
            return Request<ListNewsHeadlinesResponseDTO>("news", "?Category={category}&MaxResults={maxResults}", "GET",
            new Dictionary<string, object>
            {
                { "category", category}, 
                { "maxResults", maxResults}
            }, TimeSpan.FromMilliseconds(10000), "data");
        }

        /// <summary>
        /// Get a list of current news headlines
        /// </summary>
        /// <param name="category">Filter headlines by category</param>
        /// <param name="maxResults">Restrict the number of headlines returned</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginListNewsHeadlines(string category, int maxResults, ApiAsyncCallback<ListNewsHeadlinesResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "news", "?Category={category}&MaxResults={maxResults}", "GET",
            new Dictionary<string, object>
            {
                { "category", category}, 
                { "maxResults", maxResults}
            }, TimeSpan.FromMilliseconds(10000), "data");
        }

        public ListNewsHeadlinesResponseDTO EndListNewsHeadlines(ApiAsyncResult<ListNewsHeadlinesResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // GetNewsDetail
        // ***********************************

        /// <summary>
        /// Get the detail of a specific news story
        /// </summary>
        /// <param name="storyId">The news story Id</param>
        public GetNewsDetailResponseDTO GetNewsDetail(string storyId)
        {
            return Request<GetNewsDetailResponseDTO>("news", "/{storyId}", "GET",
            new Dictionary<string, object>
            {
                { "storyId", storyId}
            }, TimeSpan.FromMilliseconds(10000), "data");
        }

        /// <summary>
        /// Get the detail of a specific news story
        /// </summary>
        /// <param name="storyId">The news story Id</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginGetNewsDetail(string storyId, ApiAsyncCallback<GetNewsDetailResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "news", "/{storyId}", "GET",
            new Dictionary<string, object>
            {
                { "storyId", storyId}
            }, TimeSpan.FromMilliseconds(10000), "data");
        }

        public GetNewsDetailResponseDTO EndGetNewsDetail(ApiAsyncResult<GetNewsDetailResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // ListCfdMarkets
        // ***********************************

        /// <summary>
        /// Returns a list of CFD markets filtered by market name and/or market code
        /// </summary>
        /// <param name="searchByMarketName">The characters that the CFD market name should start with</param>
        /// <param name="searchByMarketCode">The characters that the market code should start with (normally this is the RIC code for the market)</param>
        /// <param name="clientAccountId">The logged on user's ClientAccountId.  (This only shows you markets that you can trade on)</param>
        /// <param name="maxResults">The maximum number of markets to return.</param>
        public ListCfdMarketsResponseDTO ListCfdMarkets(string searchByMarketName, string searchByMarketCode, int clientAccountId, int maxResults)
        {
            return Request<ListCfdMarketsResponseDTO>("cfd/markets", "?MarketName={searchByMarketName}&MarketCode={searchByMarketCode}&ClientAccountId={clientAccountId}&MaxResults={maxResults}", "GET",
            new Dictionary<string, object>
            {
                { "searchByMarketName", searchByMarketName}, 
                { "searchByMarketCode", searchByMarketCode}, 
                { "clientAccountId", clientAccountId}, 
                { "maxResults", maxResults}
            }, TimeSpan.FromMilliseconds(0), "data");
        }

        /// <summary>
        /// Returns a list of CFD markets filtered by market name and/or market code
        /// </summary>
        /// <param name="searchByMarketName">The characters that the CFD market name should start with</param>
        /// <param name="searchByMarketCode">The characters that the market code should start with (normally this is the RIC code for the market)</param>
        /// <param name="clientAccountId">The logged on user's ClientAccountId.  (This only shows you markets that you can trade on)</param>
        /// <param name="maxResults">The maximum number of markets to return.</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginListCfdMarkets(string searchByMarketName, string searchByMarketCode, int clientAccountId, int maxResults, ApiAsyncCallback<ListCfdMarketsResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "cfd/markets", "?MarketName={searchByMarketName}&MarketCode={searchByMarketCode}&ClientAccountId={clientAccountId}&MaxResults={maxResults}", "GET",
            new Dictionary<string, object>
            {
                { "searchByMarketName", searchByMarketName}, 
                { "searchByMarketCode", searchByMarketCode}, 
                { "clientAccountId", clientAccountId}, 
                { "maxResults", maxResults}
            }, TimeSpan.FromMilliseconds(0), "data");
        }

        public ListCfdMarketsResponseDTO EndListCfdMarkets(ApiAsyncResult<ListCfdMarketsResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // ListSpreadMarkets
        // ***********************************

        /// <summary>
        /// Returns a list of Spread Betting markets filtered by market name and/or market code
        /// </summary>
        /// <param name="searchByMarketName">The characters that the Spread market name should start with</param>
        /// <param name="searchByMarketCode">The characters that the Spread market code should start with (normally this is the RIC code for the market)</param>
        /// <param name="clientAccountId">The logged on user's ClientAccountId.  (This only shows you markets that you can trade on)</param>
        /// <param name="maxResults">The maximum number of markets to return.</param>
        public ListSpreadMarketsResponseDTO ListSpreadMarkets(string searchByMarketName, string searchByMarketCode, int clientAccountId, int maxResults)
        {
            return Request<ListSpreadMarketsResponseDTO>("spread/markets", "?MarketName={searchByMarketName}&MarketCode={searchByMarketCode}&ClientAccountId={clientAccountId}&MaxResults={maxResults}", "GET",
            new Dictionary<string, object>
            {
                { "searchByMarketName", searchByMarketName}, 
                { "searchByMarketCode", searchByMarketCode}, 
                { "clientAccountId", clientAccountId}, 
                { "maxResults", maxResults}
            }, TimeSpan.FromMilliseconds(10000), "data");
        }

        /// <summary>
        /// Returns a list of Spread Betting markets filtered by market name and/or market code
        /// </summary>
        /// <param name="searchByMarketName">The characters that the Spread market name should start with</param>
        /// <param name="searchByMarketCode">The characters that the Spread market code should start with (normally this is the RIC code for the market)</param>
        /// <param name="clientAccountId">The logged on user's ClientAccountId.  (This only shows you markets that you can trade on)</param>
        /// <param name="maxResults">The maximum number of markets to return.</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginListSpreadMarkets(string searchByMarketName, string searchByMarketCode, int clientAccountId, int maxResults, ApiAsyncCallback<ListSpreadMarketsResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "spread/markets", "?MarketName={searchByMarketName}&MarketCode={searchByMarketCode}&ClientAccountId={clientAccountId}&MaxResults={maxResults}", "GET",
            new Dictionary<string, object>
            {
                { "searchByMarketName", searchByMarketName}, 
                { "searchByMarketCode", searchByMarketCode}, 
                { "clientAccountId", clientAccountId}, 
                { "maxResults", maxResults}
            }, TimeSpan.FromMilliseconds(10000), "data");
        }

        public ListSpreadMarketsResponseDTO EndListSpreadMarkets(ApiAsyncResult<ListSpreadMarketsResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // Order
        // ***********************************

        /// <summary>
        /// <p>Place an order on a particular market. Post a <a onclick="dojo.hash('#type.NewStopLimitOrderRequestDTO'); return false;" class="json-link" href="#">NewStopLimitOrderRequestDTO</a> to the uri specified below.</p> <p>Do not set any order id fields when requesting a new order, the platform will generate them.</p>
        /// </summary>
        /// <param name="order">The order request</param>
        public ApiTradeOrderResponseDTO Order(NewStopLimitOrderRequestDTO order)
        {
            return Request<ApiTradeOrderResponseDTO>("order", "/newstoplimitorder", "POST",
            new Dictionary<string, object>
            {
                { "order", order}
            }, TimeSpan.FromMilliseconds(0), "trading");
        }

        /// <summary>
        /// <p>Place an order on a particular market. Post a <a onclick="dojo.hash('#type.NewStopLimitOrderRequestDTO'); return false;" class="json-link" href="#">NewStopLimitOrderRequestDTO</a> to the uri specified below.</p> <p>Do not set any order id fields when requesting a new order, the platform will generate them.</p>
        /// </summary>
        /// <param name="order">The order request</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginOrder(NewStopLimitOrderRequestDTO order, ApiAsyncCallback<ApiTradeOrderResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "order", "/newstoplimitorder", "POST",
            new Dictionary<string, object>
            {
                { "order", order}
            }, TimeSpan.FromMilliseconds(0), "trading");
        }

        public ApiTradeOrderResponseDTO EndOrder(ApiAsyncResult<ApiTradeOrderResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // CancelOrder
        // ***********************************

        /// <summary>
        /// <p>Cancel an order. Post a <a onclick="dojo.hash('#type.CancelOrderRequestDTO'); return false;" class="json-link" href="#">CancelOrderRequestDTO</a> to the uri specified below</p>
        /// </summary>
        /// <param name="cancelOrder">The cancel order request</param>
        public ApiTradeOrderResponseDTO CancelOrder(CancelOrderRequestDTO cancelOrder)
        {
            return Request<ApiTradeOrderResponseDTO>("order", "/cancel", "POST",
            new Dictionary<string, object>
            {
                { "cancelOrder", cancelOrder}
            }, TimeSpan.FromMilliseconds(0), "default");
        }

        /// <summary>
        /// <p>Cancel an order. Post a <a onclick="dojo.hash('#type.CancelOrderRequestDTO'); return false;" class="json-link" href="#">CancelOrderRequestDTO</a> to the uri specified below</p>
        /// </summary>
        /// <param name="cancelOrder">The cancel order request</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginCancelOrder(CancelOrderRequestDTO cancelOrder, ApiAsyncCallback<ApiTradeOrderResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "order", "/cancel", "POST",
            new Dictionary<string, object>
            {
                { "cancelOrder", cancelOrder}
            }, TimeSpan.FromMilliseconds(0), "default");
        }

        public ApiTradeOrderResponseDTO EndCancelOrder(ApiAsyncResult<ApiTradeOrderResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // UpdateOrder
        // ***********************************

        /// <summary>
        /// <p>Update an order (for adding a stop/limit or attaching an OCO relationship). Post an <a onclick="dojo.hash('#type.UpdateStopLimitOrderRequestDTO'); return false;" class="json-link" href="#">UpdateStopLimitOrderRequestDTO</a> to the uri specified below</p>
        /// </summary>
        /// <param name="order"><p>Update an order (for adding a stop/limit or attaching an OCO relationship).  Post an <a onclick="dojo.hash('#type.UpdateStopLimitOrderRequestDTO'); return false;" class="json-link" href="#">UpdateStopLimitOrderRequestDTO</a> to the uri specified below</p></param>
        public ApiTradeOrderResponseDTO UpdateOrder(UpdateStopLimitOrderRequestDTO order)
        {
            return Request<ApiTradeOrderResponseDTO>("order", "/updatestoplimitorder", "POST",
            new Dictionary<string, object>
            {
                { "order", order}
            }, TimeSpan.FromMilliseconds(0), "default");
        }

        /// <summary>
        /// <p>Update an order (for adding a stop/limit or attaching an OCO relationship). Post an <a onclick="dojo.hash('#type.UpdateStopLimitOrderRequestDTO'); return false;" class="json-link" href="#">UpdateStopLimitOrderRequestDTO</a> to the uri specified below</p>
        /// </summary>
        /// <param name="order"><p>Update an order (for adding a stop/limit or attaching an OCO relationship).  Post an <a onclick="dojo.hash('#type.UpdateStopLimitOrderRequestDTO'); return false;" class="json-link" href="#">UpdateStopLimitOrderRequestDTO</a> to the uri specified below</p></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginUpdateOrder(UpdateStopLimitOrderRequestDTO order, ApiAsyncCallback<ApiTradeOrderResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "order", "/updatestoplimitorder", "POST",
            new Dictionary<string, object>
            {
                { "order", order}
            }, TimeSpan.FromMilliseconds(0), "default");
        }

        public ApiTradeOrderResponseDTO EndUpdateOrder(ApiAsyncResult<ApiTradeOrderResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // ListOpenPositions
        // ***********************************

        /// <summary>
        /// <p>Queries for a specified trading account's trades / open positions.</p> <p>This uri is intended to be used to support a grid in a UI. One usage pattern is to subscribe to streaming orders, call this for the initial data to display in the grid, and call <a onclick="dojo.hash('#service.GetOpenPosition'); return false;" class="json-link" href="#">GetOpenPosition</a> when you get updates on the order stream to get the updated data in this format.</p>
        /// </summary>
        /// <param name="tradingAccountId">The trading account to get orders for.</param>
        public ListOpenPositionsResponseDTO ListOpenPositions(int tradingAccountId)
        {
            return Request<ListOpenPositionsResponseDTO>("order", "/openpositions?TradingAccountId={tradingAccountId}", "GET",
            new Dictionary<string, object>
            {
                { "tradingAccountId", tradingAccountId}
            }, TimeSpan.FromMilliseconds(0), "default");
        }

        /// <summary>
        /// <p>Queries for a specified trading account's trades / open positions.</p> <p>This uri is intended to be used to support a grid in a UI. One usage pattern is to subscribe to streaming orders, call this for the initial data to display in the grid, and call <a onclick="dojo.hash('#service.GetOpenPosition'); return false;" class="json-link" href="#">GetOpenPosition</a> when you get updates on the order stream to get the updated data in this format.</p>
        /// </summary>
        /// <param name="tradingAccountId">The trading account to get orders for.</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginListOpenPositions(int tradingAccountId, ApiAsyncCallback<ListOpenPositionsResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "order", "/openpositions?TradingAccountId={tradingAccountId}", "GET",
            new Dictionary<string, object>
            {
                { "tradingAccountId", tradingAccountId}
            }, TimeSpan.FromMilliseconds(0), "default");
        }

        public ListOpenPositionsResponseDTO EndListOpenPositions(ApiAsyncResult<ListOpenPositionsResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // ListActiveStopLimitOrders
        // ***********************************

        /// <summary>
        /// <p>Queries for a specified trading account's active stop / limit orders.</p> <p>This uri is intended to be used to support a grid in a UI. One usage pattern is to subscribe to streaming orders, call this for the initial data to display in the grid, and call <a onclick="dojo.hash('#service.GetActiveStopLimitOrder'); return false;" class="json-link" href="#">GetActiveStopLimitOrder</a> when you get updates on the order stream to get the updated data in this format.</p>
        /// </summary>
        /// <param name="tradingAccountId">The trading account to get orders for.</param>
        public ListActiveStopLimitOrderResponseDTO ListActiveStopLimitOrders(int tradingAccountId)
        {
            return Request<ListActiveStopLimitOrderResponseDTO>("order", "/activestoplimitorders?TradingAccountId={tradingAccountId}", "GET",
            new Dictionary<string, object>
            {
                { "tradingAccountId", tradingAccountId}
            }, TimeSpan.FromMilliseconds(0), "default");
        }

        /// <summary>
        /// <p>Queries for a specified trading account's active stop / limit orders.</p> <p>This uri is intended to be used to support a grid in a UI. One usage pattern is to subscribe to streaming orders, call this for the initial data to display in the grid, and call <a onclick="dojo.hash('#service.GetActiveStopLimitOrder'); return false;" class="json-link" href="#">GetActiveStopLimitOrder</a> when you get updates on the order stream to get the updated data in this format.</p>
        /// </summary>
        /// <param name="tradingAccountId">The trading account to get orders for.</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginListActiveStopLimitOrders(int tradingAccountId, ApiAsyncCallback<ListActiveStopLimitOrderResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "order", "/activestoplimitorders?TradingAccountId={tradingAccountId}", "GET",
            new Dictionary<string, object>
            {
                { "tradingAccountId", tradingAccountId}
            }, TimeSpan.FromMilliseconds(0), "default");
        }

        public ListActiveStopLimitOrderResponseDTO EndListActiveStopLimitOrders(ApiAsyncResult<ListActiveStopLimitOrderResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // GetActiveStopLimitOrder
        // ***********************************

        /// <summary>
        /// <p>Queries for a active stop limit order with a specified order id. It will return a null value if the order doesn't exist, or is not an active stop limit order.<p> <p>This uri is intended to be used to support a grid in a UI. One usage pattern is to subscribe to streaming orders, call <a onclick="dojo.hash('#service.ListActiveStopLimitOrders'); return false;" class="json-link" href="#">ListActiveStopLimitOrders</a> for the initial data to display in the grid, and call this uri when you get updates on the order stream to get the updated data in this format.</p> <p>For a more comprehensive order response, see <a onclick="dojo.hash('#service.GetOrder'); return false;" class="json-link" href="#">GetOrder</a><p>
        /// </summary>
        /// <param name="orderId">The requested order id.</param>
        public GetActiveStopLimitOrderResponseDTO GetActiveStopLimitOrder(string orderId)
        {
            return Request<GetActiveStopLimitOrderResponseDTO>("order", "/{orderId}/activestoplimitorder", "GET",
            new Dictionary<string, object>
            {
                { "orderId", orderId}
            }, TimeSpan.FromMilliseconds(0), "default");
        }

        /// <summary>
        /// <p>Queries for a active stop limit order with a specified order id. It will return a null value if the order doesn't exist, or is not an active stop limit order.<p> <p>This uri is intended to be used to support a grid in a UI. One usage pattern is to subscribe to streaming orders, call <a onclick="dojo.hash('#service.ListActiveStopLimitOrders'); return false;" class="json-link" href="#">ListActiveStopLimitOrders</a> for the initial data to display in the grid, and call this uri when you get updates on the order stream to get the updated data in this format.</p> <p>For a more comprehensive order response, see <a onclick="dojo.hash('#service.GetOrder'); return false;" class="json-link" href="#">GetOrder</a><p>
        /// </summary>
        /// <param name="orderId">The requested order id.</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginGetActiveStopLimitOrder(string orderId, ApiAsyncCallback<GetActiveStopLimitOrderResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "order", "/{orderId}/activestoplimitorder", "GET",
            new Dictionary<string, object>
            {
                { "orderId", orderId}
            }, TimeSpan.FromMilliseconds(0), "default");
        }

        public GetActiveStopLimitOrderResponseDTO EndGetActiveStopLimitOrder(ApiAsyncResult<GetActiveStopLimitOrderResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // GetOpenPosition
        // ***********************************

        /// <summary>
        /// <p>Queries for a trade / open position with a specified order id. It will return a null value if the order doesn't exist, or is not a trade / open position.</p> <p>This uri is intended to be used to support a grid in a UI. One usage pattern is to subscribe to streaming orders, call <a onclick="dojo.hash('#service.ListOpenPositions'); return false;" class="json-link" href="#">ListOpenPositions</a> for the initial data to display in the grid, and call this uri when you get updates on the order stream to get the updated data in this format.</p> <p>For a more comprehensive order response, see <a onclick="dojo.hash('#service.GetOrder'); return false;" class="json-link" href="#">GetOrder</a><p>
        /// </summary>
        /// <param name="orderId">The requested order id.</param>
        public GetOpenPositionResponseDTO GetOpenPosition(string orderId)
        {
            return Request<GetOpenPositionResponseDTO>("order", "/{orderId}/openposition", "GET",
            new Dictionary<string, object>
            {
                { "orderId", orderId}
            }, TimeSpan.FromMilliseconds(0), "default");
        }

        /// <summary>
        /// <p>Queries for a trade / open position with a specified order id. It will return a null value if the order doesn't exist, or is not a trade / open position.</p> <p>This uri is intended to be used to support a grid in a UI. One usage pattern is to subscribe to streaming orders, call <a onclick="dojo.hash('#service.ListOpenPositions'); return false;" class="json-link" href="#">ListOpenPositions</a> for the initial data to display in the grid, and call this uri when you get updates on the order stream to get the updated data in this format.</p> <p>For a more comprehensive order response, see <a onclick="dojo.hash('#service.GetOrder'); return false;" class="json-link" href="#">GetOrder</a><p>
        /// </summary>
        /// <param name="orderId">The requested order id.</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginGetOpenPosition(string orderId, ApiAsyncCallback<GetOpenPositionResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "order", "/{orderId}/openposition", "GET",
            new Dictionary<string, object>
            {
                { "orderId", orderId}
            }, TimeSpan.FromMilliseconds(0), "default");
        }

        public GetOpenPositionResponseDTO EndGetOpenPosition(ApiAsyncResult<GetOpenPositionResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // ListTradeHistory
        // ***********************************

        /// <summary>
        /// <p>Queries for a specified trading account's trade history. The result set will contain orders with a status of <b>(3 - Open, 9 - Closed)</b>, and includes <b>orders that were a trade / stop / limit order</b>.</p> <p>There's currently no corresponding GetTradeHistory (as with ListOpenPositions).</p>
        /// </summary>
        /// <param name="tradingAccountId">The trading account to get orders for.</param>
        /// <param name="maxResults">The maximum results to return.</param>
        public ListTradeHistoryResponseDTO ListTradeHistory(int tradingAccountId, int maxResults)
        {
            return Request<ListTradeHistoryResponseDTO>("order", "/tradehistory?TradingAccountId={tradingAccountId}&MaxResults={maxResults}", "GET",
            new Dictionary<string, object>
            {
                { "tradingAccountId", tradingAccountId}, 
                { "maxResults", maxResults}
            }, TimeSpan.FromMilliseconds(0), "default");
        }

        /// <summary>
        /// <p>Queries for a specified trading account's trade history. The result set will contain orders with a status of <b>(3 - Open, 9 - Closed)</b>, and includes <b>orders that were a trade / stop / limit order</b>.</p> <p>There's currently no corresponding GetTradeHistory (as with ListOpenPositions).</p>
        /// </summary>
        /// <param name="tradingAccountId">The trading account to get orders for.</param>
        /// <param name="maxResults">The maximum results to return.</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginListTradeHistory(int tradingAccountId, int maxResults, ApiAsyncCallback<ListTradeHistoryResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "order", "/tradehistory?TradingAccountId={tradingAccountId}&MaxResults={maxResults}", "GET",
            new Dictionary<string, object>
            {
                { "tradingAccountId", tradingAccountId}, 
                { "maxResults", maxResults}
            }, TimeSpan.FromMilliseconds(0), "default");
        }

        public ListTradeHistoryResponseDTO EndListTradeHistory(ApiAsyncResult<ListTradeHistoryResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // ListStopLimitOrderHistory
        // ***********************************

        /// <summary>
        /// <p>Queries for a specified trading account's stop / limit order history. The result set will include <b>only orders that were originally stop / limit orders</b> that currently have one of the following statuses <b>(3 - Open, 4 - Cancelled, 5 - Rejected, 9 - Closed, 10 - Red Card)</b> </p> <p>There's currently no corresponding GetStopLimitOrderHistory (as with ListActiveStopLimitOrders).</p>
        /// </summary>
        /// <param name="tradingAccountId">The trading account to get orders for.</param>
        /// <param name="maxResults">the maximum results to return.</param>
        public ListStopLimitOrderHistoryResponseDTO ListStopLimitOrderHistory(int tradingAccountId, int maxResults)
        {
            return Request<ListStopLimitOrderHistoryResponseDTO>("order", "/stoplimitorderhistory?TradingAccountId={tradingAccountId}&MaxResults={maxResults}", "GET",
            new Dictionary<string, object>
            {
                { "tradingAccountId", tradingAccountId}, 
                { "maxResults", maxResults}
            }, TimeSpan.FromMilliseconds(0), "default");
        }

        /// <summary>
        /// <p>Queries for a specified trading account's stop / limit order history. The result set will include <b>only orders that were originally stop / limit orders</b> that currently have one of the following statuses <b>(3 - Open, 4 - Cancelled, 5 - Rejected, 9 - Closed, 10 - Red Card)</b> </p> <p>There's currently no corresponding GetStopLimitOrderHistory (as with ListActiveStopLimitOrders).</p>
        /// </summary>
        /// <param name="tradingAccountId">The trading account to get orders for.</param>
        /// <param name="maxResults">the maximum results to return.</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginListStopLimitOrderHistory(int tradingAccountId, int maxResults, ApiAsyncCallback<ListStopLimitOrderHistoryResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "order", "/stoplimitorderhistory?TradingAccountId={tradingAccountId}&MaxResults={maxResults}", "GET",
            new Dictionary<string, object>
            {
                { "tradingAccountId", tradingAccountId}, 
                { "maxResults", maxResults}
            }, TimeSpan.FromMilliseconds(0), "default");
        }

        public ListStopLimitOrderHistoryResponseDTO EndListStopLimitOrderHistory(ApiAsyncResult<ListStopLimitOrderHistoryResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // GetOrder
        // ***********************************

        /// <summary>
        /// <p>Queries for an order by a specific order id.</p> <p>The current implementation only returns active orders (i.e. those with a status of <b>1 - Pending, 2 - Accepted, 3 - Open, 6 - Suspended, 8 - Yellow Card, 11 - Triggered)</b>.</p>
        /// </summary>
        /// <param name="orderId">The requested order id.</param>
        public GetOrderResponseDTO GetOrder(string orderId)
        {
            return Request<GetOrderResponseDTO>("order", "/{orderId}", "GET",
            new Dictionary<string, object>
            {
                { "orderId", orderId}
            }, TimeSpan.FromMilliseconds(0), "default");
        }

        /// <summary>
        /// <p>Queries for an order by a specific order id.</p> <p>The current implementation only returns active orders (i.e. those with a status of <b>1 - Pending, 2 - Accepted, 3 - Open, 6 - Suspended, 8 - Yellow Card, 11 - Triggered)</b>.</p>
        /// </summary>
        /// <param name="orderId">The requested order id.</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginGetOrder(string orderId, ApiAsyncCallback<GetOrderResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "order", "/{orderId}", "GET",
            new Dictionary<string, object>
            {
                { "orderId", orderId}
            }, TimeSpan.FromMilliseconds(0), "default");
        }

        public GetOrderResponseDTO EndGetOrder(ApiAsyncResult<GetOrderResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // Trade
        // ***********************************

        /// <summary>
        /// <p>Place a trade on a particular market. Post a <a onclick="dojo.hash('#type.NewTradeOrderRequestDTO'); return false;" class="json-link" href="#">NewTradeOrderRequestDTO</a> to the uri specified below.</p> <p>Do not set any order id fields when requesting a new trade, the platform will generate them.</p>
        /// </summary>
        /// <param name="trade">The trade request</param>
        public ApiTradeOrderResponseDTO Trade(NewTradeOrderRequestDTO trade)
        {
            return Request<ApiTradeOrderResponseDTO>("order", "/newtradeorder", "POST",
            new Dictionary<string, object>
            {
                { "trade", trade}
            }, TimeSpan.FromMilliseconds(0), "trading");
        }

        /// <summary>
        /// <p>Place a trade on a particular market. Post a <a onclick="dojo.hash('#type.NewTradeOrderRequestDTO'); return false;" class="json-link" href="#">NewTradeOrderRequestDTO</a> to the uri specified below.</p> <p>Do not set any order id fields when requesting a new trade, the platform will generate them.</p>
        /// </summary>
        /// <param name="trade">The trade request</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginTrade(NewTradeOrderRequestDTO trade, ApiAsyncCallback<ApiTradeOrderResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "order", "/newtradeorder", "POST",
            new Dictionary<string, object>
            {
                { "trade", trade}
            }, TimeSpan.FromMilliseconds(0), "trading");
        }

        public ApiTradeOrderResponseDTO EndTrade(ApiAsyncResult<ApiTradeOrderResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // UpdateTrade
        // ***********************************

        /// <summary>
        /// Update a trade (for adding a stop/limit etc). Post an <a onclick="dojo.hash('#type.UpdateTradeOrderRequestDTO'); return false;" class="json-link" href="#">UpdateTradeOrderRequestDTO</a> to the uri specified below</p>
        /// </summary>
        /// <param name="update">The trade request</param>
        public ApiTradeOrderResponseDTO UpdateTrade(UpdateTradeOrderRequestDTO update)
        {
            return Request<ApiTradeOrderResponseDTO>("order", "/updatetradeorder", "POST",
            new Dictionary<string, object>
            {
                { "update", update}
            }, TimeSpan.FromMilliseconds(0), "trading");
        }

        /// <summary>
        /// Update a trade (for adding a stop/limit etc). Post an <a onclick="dojo.hash('#type.UpdateTradeOrderRequestDTO'); return false;" class="json-link" href="#">UpdateTradeOrderRequestDTO</a> to the uri specified below</p>
        /// </summary>
        /// <param name="update">The trade request</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginUpdateTrade(UpdateTradeOrderRequestDTO update, ApiAsyncCallback<ApiTradeOrderResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "order", "/updatetradeorder", "POST",
            new Dictionary<string, object>
            {
                { "update", update}
            }, TimeSpan.FromMilliseconds(0), "trading");
        }

        public ApiTradeOrderResponseDTO EndUpdateTrade(ApiAsyncResult<ApiTradeOrderResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // GetClientAndTradingAccount
        // ***********************************

        /// <summary>
        /// Returns the Users ClientAccountId and a list of their TradingAccounts. There are no parameters for this call.
        /// </summary>
        public AccountInformationResponseDTO GetClientAndTradingAccount()
        {
            return Request<AccountInformationResponseDTO>("useraccount", "/UserAccount/ClientAndTradingAccount", "GET",
            new Dictionary<string, object>
            {

            }, TimeSpan.FromMilliseconds(0), "data");
        }

        /// <summary>
        /// Returns the Users ClientAccountId and a list of their TradingAccounts. There are no parameters for this call.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginGetClientAndTradingAccount(ApiAsyncCallback<AccountInformationResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "useraccount", "/UserAccount/ClientAndTradingAccount", "GET",
            new Dictionary<string, object>
            {

            }, TimeSpan.FromMilliseconds(0), "data");
        }

        public AccountInformationResponseDTO EndGetClientAndTradingAccount(ApiAsyncResult<AccountInformationResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

        // ***********************************
        // GenerateException
        // ***********************************

        /// <summary>
        /// Simulates an error condition.
        /// </summary>
        /// <param name="errorCode">Simulates an error condition.</param>
        public ApiErrorResponseDTO GenerateException(int errorCode)
        {
            return Request<ApiErrorResponseDTO>("errors", "?errorCode={errorCode}", "GET",
            new Dictionary<string, object>
            {
                { "errorCode", errorCode}
            }, TimeSpan.FromMilliseconds(0), "data");
        }

        /// <summary>
        /// Simulates an error condition.
        /// </summary>
        /// <param name="errorCode">Simulates an error condition.</param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public void BeginGenerateException(int errorCode, ApiAsyncCallback<ApiErrorResponseDTO> callback, object state)
        {
            BeginRequest(callback, state, "errors", "?errorCode={errorCode}", "GET",
            new Dictionary<string, object>
            {
                { "errorCode", errorCode}
            }, TimeSpan.FromMilliseconds(0), "data");
        }

        public ApiErrorResponseDTO EndGenerateException(ApiAsyncResult<ApiErrorResponseDTO> asyncResult)
        {
            return EndRequest(asyncResult);
        }

    }
}