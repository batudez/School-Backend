using Application.Features.Notes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Notes;

public class NoteManager : INoteService
{
    private readonly INoteRepository _noteRepository;
    private readonly NoteBusinessRules _noteBusinessRules;

    public NoteManager(INoteRepository noteRepository, NoteBusinessRules noteBusinessRules)
    {
        _noteRepository = noteRepository;
        _noteBusinessRules = noteBusinessRules;
    }

    public async Task<Note?> GetAsync(
        Expression<Func<Note, bool>> predicate,
        Func<IQueryable<Note>, IIncludableQueryable<Note, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Note? note = await _noteRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return note;
    }

    public async Task<IPaginate<Note>?> GetListAsync(
        Expression<Func<Note, bool>>? predicate = null,
        Func<IQueryable<Note>, IOrderedQueryable<Note>>? orderBy = null,
        Func<IQueryable<Note>, IIncludableQueryable<Note, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Note> noteList = await _noteRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return noteList;
    }

    public async Task<Note> AddAsync(Note note)
    {
        Note addedNote = await _noteRepository.AddAsync(note);

        return addedNote;
    }

    public async Task<Note> UpdateAsync(Note note)
    {
        Note updatedNote = await _noteRepository.UpdateAsync(note);

        return updatedNote;
    }

    public async Task<Note> DeleteAsync(Note note, bool permanent = false)
    {
        Note deletedNote = await _noteRepository.DeleteAsync(note);

        return deletedNote;
    }
}
