using Application.Features.Notes.Commands.Update;
using Application.Features.Notes.Rules;
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
        //private readonly INoteBusinessRules _noteBusinessRules;

        public UpdateGradesCommandHandler(INoteRepository noteRepository, IMapper mapper, ILogger<UpdateGradesCommandHandler> logger)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
            _logger = logger;
            //_noteBusinessRules = noteBusinessRules;
        }

        public async Task<UpdatedGradesResponse> Handle(UpdateGradesCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Notlar Kaydedildi.");
            var updatedNotes = new List<Note>();

            foreach (var gradeUpdate in request.GradeUpdates)
            {
                // Öğrencinin mevcut notunu alıyoruz
                Note? note = await _noteRepository.GetAsync(predicate: n => n.StudentId == gradeUpdate.StudentId,
                    cancellationToken: cancellationToken);

                // Notun var olup olmadığını kontrol ediyoruz
                //await _noteBusinessRules.NoteShouldExistWhenSelected(note);

                // Yeni notu not nesnesine güncelliyoruz
                note.Value = gradeUpdate.Value;

                // Veritabanında güncellemeyi gerçekleştiriyoruz
                await _noteRepository.UpdateAsync(note!);

                updatedNotes.Add(note);
            }

            // Geri döneceğimiz response'ı oluşturuyoruz
            var response = new UpdatedGradesResponse
            {
                UpdatedNotes = _mapper.Map<List<UpdatedNoteResponse>>(updatedNotes)
            };

            
            return response;
        }
    }
}