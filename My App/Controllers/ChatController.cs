using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly OpenAIService _openAIService;

    public ChatController(OpenAIService openAIService)
    {
        _openAIService = openAIService;
    }

    [HttpPost("ask")]
    public async Task<IActionResult> Ask([FromBody] ChatRequest request)
    {
        var response = await _openAIService.GetChatGPTResponse(request.Message);
        return Ok(new { reply = response });
    }
}

public class ChatRequest
{
    public required string Message { get; set; }
}
