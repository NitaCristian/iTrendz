using iTrendz.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace iTrendz.API.Controllers;

public class FileController(IWebHostEnvironment env) : ControllerBase
{
	[HttpPost]

	public async Task<ActionResult<List<UploadResult>>> UploadFiles(List<IFormFile> files)
	{
		List<UploadResult> uploadResults = [];
		foreach (var file in files)
		{
			var uploadResult = new UploadResult();
			string trustedFileNameForFileStorage;
			var untrustedFileName = file.Name;
			uploadResult.FileName = untrustedFileName;
			var trustedFileNameForDisplay = WebUtility.HtmlEncode(untrustedFileName);

			trustedFileNameForFileStorage = Path.GetRandomFileName();
			var path = Path.Combine(env.ContentRootPath, "uploads", trustedFileNameForFileStorage);

			await using FileStream fs = new(path, FileMode.Create);
			await file.CopyToAsync(fs);
			uploadResult.StoredFileName = trustedFileNameForFileStorage;
			uploadResults.Add(uploadResult);
		}

		return Ok(uploadResults);
	}
}
