using Application.Features.Notes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Notes.Rules;

public class NoteBusinessRules : BaseBusinessRules
{
    private readonly INoteRepository _noteRepository;
    private readonly ILocalizationService _localizationService;

    public NoteBusinessRules(INoteRepository noteRepository, ILocalizationService localizationService)
    {
        _noteRepository = noteRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, NotesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task NoteShouldExistWhenSelected(Note? note)
    {
        if (note == null)
            await throwBusinessException(NotesBusinessMessages.NoteNotExists);
    }

    public async Task NoteIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Note? note = await _noteRepository.GetAsync(
            predicate: n => n.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await NoteShouldExistWhenSelected(note);
    }
}