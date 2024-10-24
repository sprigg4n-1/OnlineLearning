using EntityBLL.DTO.Request;
using EntityBLL.DTO.Response;
using EntityBLL.Interfaces.Services;
using EntityDAL.Parameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OnlineLearning.Extension;
using EntityDAL.Exceptions;

namespace OnlineLearning.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TestQuestionController : ControllerBase
    {
        private readonly ITestQuestionService testQuestionService;

        public TestQuestionController(ITestQuestionService testQuestionService)
        {
            this.testQuestionService = testQuestionService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TestQuestionResponse>> GetAsync([FromQuery] TestParameters parameters)
        {
            try
            {
                var testQs = await testQuestionService.GetAsync(parameters);
                Response.Headers.Add("X-Pagination", testQs.SerializeMetadata());
                return Ok(testQs);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TestQuestionResponse>> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                return Ok(await testQuestionService.GetByIdAsync(id));
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> InsertAsync([FromBody] TestQuestionRequest request)
        {
            try
            {
                await testQuestionService.InsertAsync(request);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateAsync([FromBody] TestQuestionRequest request)
        {
            try
            {
                await testQuestionService.UpdateAsync(request);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                await testQuestionService.DeleteAsync(id);
                return Ok();
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }
    }
}
