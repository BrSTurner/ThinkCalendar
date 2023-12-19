using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Think.Calendar.Application.Services;
using Think.Calendar.Application.Services.Interrfaces;
using Think.Calendar.Domain.Mediator.CommandHandlers;
using Think.Calendar.Domain.Mediator.Commands;
using Think.Calendar.Domain.Mediator.EventHandlers;
using Think.Calendar.Domain.Mediator.Interfaces;
using Think.Calendar.Domain.Mediator.Model;
using Think.Calendar.Domain.Mediator.Notifications;
using Think.Calendar.Domain.Model;
using Think.Calendar.Domain.Notificator;
using Think.Calendar.Domain.Notificator.Interfaces;
using Think.Calendar.Domain.Repositories.Interfaces;
using Think.Calendar.Domain.UnitOfWork;
using Think.Calendar.Infrastructure.Mediator;
using Think.Calendar.Infrastructure.Repositories;
using Think.Calendar.Infrastructure.UnitOfWork;

namespace Think.Calendar.CrossCutting
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddThinkCalendar(this IServiceCollection services)
        {
            AddMediator(services);
            AddInfrastructureData(services);
            AddDomainLayer(services);
            AddApplicationLayer(services);
            return services;
        }

        private static void AddApplicationLayer(IServiceCollection services)
        {
            services.AddScoped<ICalendarEventService, CalendarEventService>();
        }

        private static void AddDomainLayer(IServiceCollection services)
        {
            services.AddScoped<INotificator, Notificator>();
        }

        private static void AddInfrastructureData(IServiceCollection services)
        {
            services.AddScoped<ICalendarEventRepository, CalendarEventRespository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void AddMediator(IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IRequestHandler<AddCalendarEventCommand, CommandResult<CalendarEvent>>, CalendarEventCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCalendarEventCommand, CommandResult<CalendarEvent>>, CalendarEventCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteCalendarEventCommand, CommandResult<bool>>, CalendarEventCommandHandler>();

            services.AddScoped<INotificationHandler<CalendarEventCreatedNotification>, EmailHandler>();
            services.AddScoped<INotificationHandler<CalendarEventUpdatedNotification>, EmailHandler>();
            services.AddScoped<INotificationHandler<CalendarEventDeletedNotification>, EmailHandler>();
        }
    }
}
