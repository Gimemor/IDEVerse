using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using IdeVerseContracts.Exceptions;

namespace IDEVerse.Controllers
{
	public abstract class BaseApiContoller : ControllerBase
	{
		public async Task<ActionResult> CallAsync(Func<Task<object>> action) 
		{
			try
			{
				var response = await action();
				if (response == null)
					return NoContent();
				return Ok(response);
			}
			catch (EntityNotFoundException ex)
			{
				return NotFound(ex);
			}
			catch (BadRequestException ex) 
			{
				return BadRequest(ex);	
			}
		}

		public async Task<ActionResult> CallAsync(Func<Task> action)
		{
			try
			{
				await action();
				return NoContent();
			}
			catch (EntityNotFoundException ex)
			{
				return NotFound(ex);
			}
			catch (BadRequestException ex)
			{
				return BadRequest(ex);
			}
		}
	}
}
