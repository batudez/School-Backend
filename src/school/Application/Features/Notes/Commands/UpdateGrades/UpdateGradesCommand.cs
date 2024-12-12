using Application.Features.Notes.Commands.Update;
using Application.Features.Notes.Rules;
using Application.Services.Hubs;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Notes.Commands.UpdateGrades;
public class UpdateGradesCommand : IRequest<UpdatedGradesResponse>
{
    public List<StudentGradeUpdateDto> GradeUpdates { get; set; }

    public UpdateGradesCommand(List<StudentGradeUpdateDto> gradeUpdates)
    {
        GradeUpdates = gradeUpdates;
    }

    public class UpdateGradesCommandHandler : IRequestHandler<UpdateGradesCommand, UpdatedGradesResponse>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateGradesCommandHandler> _logger;
        private readonly INoteHubService _noteHubService;
        //private readonly INoteBusinessRules _noteBusinessRules;

        public UpdateGradesCommandHandler(INoteRepository noteRepository, IMapper mapper, ILogger<UpdateGradesCommandHandler> logger, INoteHubService noteHubService)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
            _logger = logger;
            _noteHubService = noteHubService;
            //_noteBusinessRules = noteBusinessRules;
        }

        public async Task<UpdatedGradesResponse> Handle(UpdateGradesCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Notlar Kaydedildi.");
            var updatedNotes = new List<Note>();

            foreach (var gradeUpdate in request.GradeUpdates)
            {
             
                Note? note = await _noteRepository.GetAsync(predicate: n => n.StudentId == gradeUpdate.StudentId,
                    cancellationToken: cancellationToken);

                note.Value = gradeUpdate.Value;

                await _noteRepository.UpdateAsync(note!);

                updatedNotes.Add(note);
            }

            var response = new UpdatedGradesResponse
            {
                UpdatedNotes = _mapper.Map<List<UpdatedNoteResponse>>(updatedNotes)
            };

            await _noteHubService.NoteUpdatedMessageAsync("Notlar güncellendi");
            return response;
        }
    }
}