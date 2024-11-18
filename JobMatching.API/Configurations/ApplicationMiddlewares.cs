namespace JobMatching.API.Configurations
{
	public static class ApplicationMiddlewares
	{
		public static WebApplication ConfigureApplicationMiddlewares(this WebApplication app) 
		{
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();
			
			return app;
		}
	}
}
