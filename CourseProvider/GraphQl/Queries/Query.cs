using CourseProvider.Models;
using CourseProvider.Services;

namespace CourseProvider.GraphQl.Queries;

public class Query(ICourseService courseService)
{
    private readonly ICourseService _courseService = courseService;

    [GraphQLName("getCourses")]
    public async Task<IEnumerable<Course>> GetCoursesAsync()
    {
        return await _courseService.GetCoursesAsync();
    }

    [GraphQLName("getCoursesById")]
    public async Task<Course> getCoursesByIdAsync(string id)
    {
        return await _courseService.GetCourseByIdAsync(id);
    }
}
