using CourseProviderInfrastructure.Models;
using CourseProviderInfrastructure.Services;

namespace CourseProviderInfrastructure.GraphQL;

public class CourseQuery(ICourseService courseService)
{
    private readonly ICourseService _courseService = courseService;

    [GraphQLName("getAllCourses")]

    public async Task<IEnumerable<Course>> GetCoursesAsync()
    {
        return await _courseService.GetCoursesAsync();  
    }

    [GraphQLName("getAllCourseById")]

    public async Task<Course> GetCoursesAsync(string id)
    {
        return await _courseService.GetCourseByIdAsync(id);
    }

}
