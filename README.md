Introduction

Consider a situation where you're building a website that lets users search for their favorite movies, and you use OMDB as your data source, for example:

$.getJSON('http://www.omdbapi.com/?apikey=8730e0e&i=tt0111161', function(data) {
  $('#movie-title').text(data.Title);
  $('#movie-description').text(data.Description);
  $('#movie-year').text(data.Year);
});

Imagine that it takes 500ms for OMDB to respond to a request at that particular URL. When OMDB starts receiving a large number of requests at that URL, the server will start to slow down as it has to process each and every request. As more requests come in, responses start taking 600ms... 700ms.. 800ms.. to respond, until eventually they start timing out.

    Sidenote: a majority of users abandon sites that take 3 seconds or longer to load.

A common optimization for this scenario is to introduce a "cache server" between the client (a jQuery website in this example) and the destination server (OMDB in this example). A cache allows you and your code to store a copy of frequently accessed data in some form of data structure for quick access when needed. In this example, the cache would be an ASP.NET server that sits between the website and OMDB. Adding a cache to a server could allow a single server to handle hundred of times more requests than one without a cache.

![Cache Server](https://i.imgur.com/1DKbTGd.png)

In this exercise, we're going to use the ASP.NET framework to build a server that can talk to another server and cache the results. Your web server will respond to GET requests for http://localhost:3000/ and return the data from the OMDb API. However, when making a second request to the same endpoint http://localhost:3000/?i=tt3896198, the server should not return data from the OMDB API, but instead from some object or array.

To do this, we will need to:

    Build an ASP.NET server that responds to GET requests at http://localhost:3000/
    Check the URL parameters for either an i or a t parameter.
    Proxy incoming requests to OMDB by manually crafting an HTTP request.
    Forward the URL parameters to OMDB. (For example, if i is present then append &i=${req.query.i} to the OMDB request URL. 
    If t is present, then append &t=${req.query.t} to the OMDB request URL.)
    Cache movie data using a hash table or object. (Use the provided activity diagram to grok the logic)
    Log all incoming requests using the morgan middleware library.

Setup

    Open a terminal
    Clone your starter files from Github and open the project in Visual Studio

The tests will confirm if you have completed the requirements. Type npm test and hit enter to run the tests. Then, write your code using the steps below. When you have written all the code to complete the project (based on the exit criteria) and the tests are passing, submit the assignment.

It would be a good idea at this point to take some time and read the documentation for the OMDb API.

    You'll notice the OMDb API requires you to include an apikey when making requests to their servers. 
    Be sure to include apikey as a parameter when proxying requests to OMDB, 
    e.g: '&apikey=8730e0e', 
    e.g: 'http://www.omdbapi.com/?i=' + movieId + '&apikey=8730e0e'

Click the IIS Express button to launch your project on a local webserver.
Exit Criteria

    Server should log each request using morgan's dev format.
    Server should indicate when it is listening, and on which port.
    Server should respond to GET requests to /?i=tt3896198 with movie data.
    Server should respond to GET requests to /?i=tt3896198 with movie data without fetching from the OMDb api.
    Server should also respond to GET requests to /?t=baby%20driver with movie data.
    Server should also respond to GET requests to /?t=baby%20driver with movie data without fetching from the OMDb api.
    All tests should pass.

Project Submission

To submit this project, please deploy this website using Now.

# navigate to the project
$ cd ~/projects/{project-name}

# run "now" to deploy the site
$ now

After running that command, you should see the following output:

> Deploying ~/projects/{project-name} under your@email.com
> Ready! https://{project-name}-skckceswsd.now.sh (copied to clipboard)

A URL to your project has been pasted to your clipboard, so the next thing to do is submit your Now URL using the link at the bottom to navigate to the submission page.

And that's it! Once you submit the project, you can move onto the next assignment. An instructor will evaluate your work; giving feedback if necessary.
