using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson;

var connectionString = "mongodb://localhost:27017";

var client = new MongoClient(connectionString);

var collection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("movies");

var insertResult = await collection.InsertOneAsync({ Name = "Mongo's Pizza" });

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/getAssignments", async () =>
{
    var coursesUrl = "https://canvas.instructure.com/api/v1/courses/?access_token=349~AHRH3c4DNYvQ8c9XKB8DYGCGr62CHcze9FCBD4CAEN8vn96F8WP2JKBPUcKXA3L9&enrollment_state=active";

    Dictionary<string, string> courseDictionary = new Dictionary<string, string>();

    List<dynamic> assignmentsList = new List<dynamic>();

    using (HttpClient client = new HttpClient())
    {
        using (HttpResponseMessage res = await client.GetAsync(coursesUrl))
        {
            res.EnsureSuccessStatusCode();
            var courseData = await res.Content.ReadAsStringAsync();

            var jsonData = JsonConvert.DeserializeObject<dynamic>(courseData);
            Console.WriteLine(courseData);

            foreach (var course in jsonData)
            {
                            var courseID = course.id?.ToString();
                            var courseName = course.name?.ToString();
                            if (courseID != null && courseName != null)
                            {
                                courseDictionary[courseID] = courseName;
                            }
            }
        }

        foreach (var kvp in courseDictionary)
        {
            var courseID = kvp.Key;
            var courseName = kvp.Value;

            using (HttpResponseMessage res = await client.GetAsync(
                    $"https://canvas.instructure.com/api/v1/courses/{courseID}/assignments?access_token=349~AHRH3c4DNYvQ8c9XKB8DYGCGr62CHcze9FCBD4CAEN8vn96F8WP2JKBPUcKXA3L9"))
            {
                res.EnsureSuccessStatusCode();

                var assignmentsData = await res.Content.ReadAsStringAsync();

                var jsonData = JsonConvert.DeserializeObject<dynamic>(assignmentsData);

                Console.WriteLine("Json Data for Course ID " + courseID + ": \n" + jsonData);

                foreach (var assignmentObject in jsonData)
                {
                    var assignmentName = assignmentObject.name != null ? assignmentObject.name.ToString() : "No name available";
                    var assignmentDescription = assignmentObject.description != null ? assignmentObject.description.ToString() : "No description available";
                    var assignmentDueDate = assignmentObject.due_at != null ? assignmentObject.due_at.ToString() : "No due date available";

                    var assignment = new
                    {
                        CourseName = courseName,
                        AssignmentName = assignmentName,
                        AssignmentDescription = assignmentDescription,
                        AssignmentDueDate = assignmentDueDate
                    };

                    string cleanAssignmentJson = JsonConvert.SerializeObject(assignment);
                    Console.WriteLine("Assignment Here: " + cleanAssignmentJson);

                    assignmentsList.Add(assignment);
                }
            }
        }

        var jsonResult = JsonConvert.SerializeObject(assignmentsList);
        Console.WriteLine("Final Return: \n" + jsonResult);

        return Results.Json(assignmentsList);
    }

}).WithName("GetAssignments").WithOpenApi();

app.Run();

