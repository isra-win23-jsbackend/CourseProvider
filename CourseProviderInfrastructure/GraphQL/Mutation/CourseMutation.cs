

using CourseProviderInfrastructure.Models;
using CourseProviderInfrastructure.Services;

namespace CourseProviderInfrastructure.GraphQL.Mutation;

public class CourseMutation(ICourseService courseService)
{

    private readonly ICourseService _CourseService = courseService;


    [GraphQLName("createCourses")]

    public async Task<Course> CreateCourseAsync(CourseCreateRequest input)
    {
        return await _CourseService.CreateCourseAsync(input);
    }

    [GraphQLName("UpdateCourses")]
    public async Task<Course> UpdateCourseAsync(CourseUpdateRequest input)
    {
        return await _CourseService.UpdateCourseAsync(input);
    }

    [GraphQLName("DeleteCourses")]
    public async Task<bool> CreateCourseAsync(string id)
    {
        return await _CourseService.DeleteCourseAsync(id);
    }


}
