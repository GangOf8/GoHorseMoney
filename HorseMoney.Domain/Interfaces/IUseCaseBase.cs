namespace HorseMoney.Domain.Interfaces;

/// <summary>
/// Codigo gerado para ser implementado nas interfaces dos UseCase, sendo assim uma abstração geral do codigo 
/// </summary>
/// <typeparam name="TInput"></typeparam>
/// <typeparam name="TOutput"></typeparam>
public interface IUseCaseBase<TInput, TOutput>
{
    Task<TOutput> Execute(TInput input);
}