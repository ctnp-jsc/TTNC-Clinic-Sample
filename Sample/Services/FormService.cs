using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.Entities.Models;
using Sample.Repositories;
using Sample.ViewModels;

namespace Sample.Services
{
    public sealed class FormService : BaseCrudEntityService<FormEntity, IFormRepository>
    {
        private readonly IResponseRepository _reponseRepository;
        public FormService(IServiceProvider serviceProvider, ILogger<FormService> logger) : base(serviceProvider, logger)
        {
            _reponseRepository = serviceProvider.GetRequiredService<IResponseRepository>();
        }
        public async Task<List<FormViewModel>> GetListForm(CancellationToken ct = default)
        {
            var listFormView = new List<FormViewModel>();
            var listForm = await Repository.GetListFrom(ct);
            var response = await _reponseRepository.FindManyAsync(e => true, ct);
            foreach (var form in listForm)
            {
                var rs = response.Where(e => e.ResponseDetail.Any(detail => detail.Form == form)).ToList();
                var maxRs = rs.OrderByDescending(entity => entity.Version).LastOrDefault();
                listFormView.Add(new()
                {
                    Id = form.Id,
                    Title = form.Title,
                    CreatedAt = form.CreatedAt,
                    Questions = form.Questions.ToList(),
                    LastEdited = maxRs == null ? form.CreatedAt : maxRs.CreatedAt,
                    FormStatus = maxRs == null ? FormStatus.FillOut : maxRs.IsSubmitted ? FormStatus.Submitted : FormStatus.SubmittedDraft
                });
            }
            return listFormView;
        }
        public async Task<FormEntity?> GetFormDetail(string FormId, CancellationToken ct = default)
        {
            return await Repository.GetFromDetail(FormId, ct);
        }
        public async Task<FormEntity> CreateForm(FormViewModel formModel, CancellationToken ct = default)
        {
            var form = new FormEntity()
            {
                Title = formModel.Title,
                Description = @"Dear Member,
                Answering the questions below helps us to find ways to help you continue to feel good and improve your health."
            };
            var questionList = new List<QuestionEntity>(){
                new(){
                    QuestionText = "First Name",
                    QuestionType = QuestionType.Info,
                    Order = 1,
                    IsMandatory = true,
                    Answers = new List<AnswerEntity>(){
                        new(){Answer = ""}
                    }
                },
                new(){
                    QuestionText = "Last Name",
                    QuestionType = QuestionType.Info,
                    Order = 2,
                    IsMandatory = true,
                    Answers = new List<AnswerEntity>(){
                        new(){Answer = ""}
                    }
                },
                new(){
                    QuestionText = "DOB",
                    QuestionType = QuestionType.Info,
                    Order = 3,
                    IsMandatory = true,
                    QuestionDataType = QuestionDataType.Date,
                    Answers = new List<AnswerEntity>(){
                        new(){Answer = ""}
                    }
                },
                new(){
                    QuestionText = "Gender",
                    QuestionType = QuestionType.Info,
                    Order = 4,
                    IsMandatory = true,
                    QuestionDataType = QuestionDataType.Boolean,
                    Answers = new List<AnswerEntity>(){
                        new(){Answer = "Male"},
                        new(){Answer = "Female"}
                    }
                },
                new(){
                    QuestionText = "What language do you prefer to speak?",
                    QuestionType = QuestionType.SingleOpen,
                    Order = 5,
                    IsMandatory = false,
                    QuestionDataType = QuestionDataType.Text,
                    QuestionCategory = "Contact Preferences",
                    Answers = new List<AnswerEntity>(){
                        new(){Answer = "English"},
                        new(){Answer = "Vietnamese"},
                        new(){Answer = "Spanish"},
                        new(){Answer = "Korean"},
                        new(){Answer = "Madarin"},
                        new(){Answer = "Catonese"},
                        new(){Answer = "Taiwanese"},
                        new(){Answer = "Other", ExtraAnswer = true, Order = 1},
                    }
                },
                new(){
                    QuestionText = "What health condition do you currently have?",
                    QuestionType = QuestionType.Multiple,
                    Order = 6,
                    IsMandatory = false,
                    QuestionDataType = QuestionDataType.Text,
                    QuestionCategory = "Current Health Conditions",
                    QuestionCategoryDescription = "Please mark each condition that applies to you",
                    Answers = new List<AnswerEntity>(){
                        new(){Answer = "Asthma"},
                        new(){Answer = "COPD"},
                        new(){Answer = "Kidney diease or kidney failure"},
                        new(){Answer = "Diabetes or high blood sugar"},

                    }
                }

            };
            form.Questions = questionList;
            return await Repository.AddFormAsync(form, ct);
        }
    }
}
