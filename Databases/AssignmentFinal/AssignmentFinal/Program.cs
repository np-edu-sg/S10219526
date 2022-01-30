// See https://aka.ms/new-console-template for more information

using AssignmentFinal;
using AssignmentFinal.Models;
using Microsoft.EntityFrameworkCore;

using var context = new AssignmentFinalContext();
// Console.WriteLine(context.Database.EnsureDeleted());
Console.WriteLine(context.Database.EnsureCreated());

var events = new List<Event>
{
    new Event
    {
        EventName = "Movie Masterclass",
        EventDescr = "Learn the fundamentals of great movie making.",
        Etid = 5
    },
    new Event
    {
        EventName = "Cooking Masterclass",
        EventDescr = "Learn the fundamentals of making great tasting dishes.",
        Etid = 5
    },
    new Event
    {
        EventName = "Big data workshop",
        EventDescr = "Learn the fundamentals of data analytics and artificial intelligence.",
        Etid = 5
    },
    new Event
    {
        EventName = "Interstellar",
        EventDescr = "Watch the record winning Interstellar by Christopher Nolan.",
        Etid = 2
    },
    new Event
    {
        EventName = "UP",
        EventDescr = "Watch the classic UP animated film.",
        Etid = 2
    },
    new Event
    {
        EventName = "Mr Bean",
        EventDescr = "Watch the comedy show Mr Bean.",
        Etid = 2
    },
    new Event
    {
        EventName = "Spiderman: No way home",
        EventDescr =
            "Watch the newly released Spiderman film featuring Tom Holland, Andrew Garfield and Tobey Maguire.",
        Etid = 2
    },
    new Event
    {
        EventName = "Phantom the Musical",
        EventDescr = "Award winning musical Phantom the Musical is live on board your cruise.",
        Etid = 3
    },
    new Event
    {
        EventName = "Classical Music Performance",
        EventDescr = "Enjoy a show of classical music.",
        Etid = 3
    },
    new Event
    {
        EventName = "Origami Workshop",
        EventDescr =
            "Learn how to fold the animal of your desire with our Origami workshop suitable for anyone.",
        Etid = 4
    },
    new Event
    {
        EventName = "Paper Plane Folding Workshop",
        EventDescr = "Learn how to fold the best flying paper plane.",
        Etid = 4
    },
    new Event
    {
        EventName = "Baking Workshop",
        EventDescr = "Bake different kinds of food, including classic toast to cupcakes.",
        Etid = 4
    },
    new Event
    {
        EventName = "Table Tennis Competition",
        EventDescr = "Participate or watch a live table tennis tournament.",
        Etid = 1
    },
    new Event
    {
        EventName = "Basketball Competition",
        EventDescr = "Participate or watch a live basketball tournament.",
        Etid = 1
    },
};

var loc = new Dictionary<int, string>
{
    {1, "Sports Hall"},
    {2, "Movie Theatre"},
    {3, "Musical Hall"},
    {4, "Workshop Room"},
    {5, "Training Hall"},
};

var mins = new List<int>
{
    30, 45, 15
};

var durations = new List<double>
{
    1, 1.5, 2, 2.5, 3, 3.5
};

foreach (var e in events)
{
    e.EventLoc = $"{loc[e.Etid]} {new Random().Next(1, 5)}";
    e.EventCapacity = new Random().Next(10, 50);
    e.EventDuration = durations[new Random().Next(0, 5)];
    e.MinAge = 8;
    e.MaxAge = 100;
    e.AdultPrice = new Random().Next(0, 50);
    e.ChildPrice = Math.Floor((double) e.AdultPrice * ((double) 2 / 3));

    context.Events.Add(e);
    context.SaveChanges();

    var ii = 1;
    for (var idx = 0; idx < new Random().Next(1, 10); idx++)
    {
        var s = new EventSession
        {
            SessionNo = ii,
            Event = e,
            EventDateTime = new DateTime(2022, 1, 4)
                .AddDays(new Random().Next(0, 10))
                .AddHours(new Random().Next(3, 24))
                .AddMinutes(mins[new Random().Next(0, 2)])
        };

        context.EventSessions.Add(s);
        ii++;
    }
}

var statuses = new List<string> {"Confirm", "Waitlist"};

var sessions = context.EventSessions.Include(e => e.Event).ToList();
context.Passengers.ToList().ForEach(p =>
{
    for (var idx = 0; idx < new Random().Next(0, 5); idx++)
    {
        var s = sessions[new Random().Next(0, sessions.Count - 1)];
        
        DateTime bookdt;
        while (true)
        {
            bookdt = new DateTime(2022, 1, 4)
                .AddDays(new Random().Next(0, 10))
                .AddHours(new Random().Next(0, 24))
                .AddMinutes(new Random().Next(0, 60));
            if (bookdt < s.EventDateTime) break;
        }

        var b = new Booking
        {
            NoOfAdultTicket = new Random().Next(1, 4),
            NoOfChildTicket = new Random().Next(0, 4),
            AdultSalesPrice = s.Event.AdultPrice,
            ChildSalesPrice = s.Event.ChildPrice,
            BookDateTime = bookdt,
            BookStatus = statuses[new Random().Next(0, 2)],
            EventSession = s,
            Pgr = p,
        };

        context.Bookings.Add(b);
    }
});

context.SaveChanges();