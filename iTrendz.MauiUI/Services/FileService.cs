using iTrendz.Domain.DTOs;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace iTrendz.MauiUI.Services;

public class FileService(HttpClient httpClient)
{
	private const int _maxAllowedFiles = int.MaxValue;
	private const long _maxFileSize = long.MaxValue;
	public async Task<List<UploadResult>> UploadFiles(List<IBrowserFile> files)
	{
		using var content = new MultipartFormDataContent();

		foreach (var file in files)
		{
			var fileContent = new StreamContent(file.OpenReadStream(_maxFileSize));
			fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
			content.Add(
				content: fileContent,
				name: "\"files\"",
				fileName: file.Name);
		}

		var response = await httpClient.PostAsync("/api/File/", content);
		var results = await response.Content.ReadFromJsonAsync<List<UploadResult>>();
		return results;
	}
}
