using CarBuilderAPI.Models;
using CarBuilderAPI.Models.DTOs;


// Define Collections
List<Interior> interiors = new List<Interior>
{
    new Interior()
    {
        Id = 1, Material = "Beige Fabric", Price = 150.00M
    },
    new Interior()
    {
        Id = 2, Material = "Charcoal Fabric", Price = 175.00M
    },
    new Interior()
    {
        Id = 3, Material = "White Leather", Price = 250.00M
    },
    new Interior()
    {
        Id = 4, Material = "Black Leather", Price = 250.00M
    }
};
List<Order> orders = new List<Order>
{
    new Order()
    {
        Id = 1,
        Timestamp = DateTime.Today,
        WheelsId = 1,
        TechnologyId = 1,
        PaintColorId = 1,
        InteriorId = 1
    }
};
List<PaintColor> paintColors = new List<PaintColor>
{
    new PaintColor()
    {
        Id = 1, Color = "Silver", Price = 100.00M
    },
    new PaintColor()
    {
        Id = 2, Color = "Midnight Blue", Price = 150.00M
    },
    new PaintColor()
    {
        Id = 3, Color = "Firebrick Red", Price = 200.00M
    },
    new PaintColor()
    {
        Id = 4, Color = "Spring Green", Price = 200.00M
    }
};
List<Technology> technologies = new List<Technology>
{
    new Technology()
    {
        Id = 1, Package = "Basic Package (basic sound system)", Price = 150.00M
    },
    new Technology()
    {
        Id = 2, Package = "Navigation Package (includes integrated navigation controls)", Price = 250.00M
    },
    new Technology()
    {
        Id = 3, Package = "Visibility Package (includes side and rear cameras)", Price = 250.00M
    },
    new Technology()
    {
        Id = 4, Package = "Ultra Package (includes navigation and visibility packages)", Price = 400.00M
    }
};
List<Wheels> wheels = new List<Wheels>
{
    new Wheels()
    {
        Id = 1, Style = "17-inch Pair Radial Silver", Price = 200.00M
    },
    new Wheels()
    {
        Id = 2, Style = "17-inch Pair Radial Black", Price = 250.00M
    },
    new Wheels()
    {
        Id = 3, Style = "18-inch Pair Spoke Silver", Price = 325.00M
    },
    new Wheels()
    {
        Id = 4, Style = "18-inch Pair Spoke Black", Price = 375.00M
    }
};


/////////       SWAGGER       /////////
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
//////////////////////////////////////


// endpoint for fetching wheels
app.MapGet("/wheels", () => 
{
    return wheels.Select(w => new WheelsDTO
    {
        Id = w.Id,
        Price = w.Price,
        Style = w.Style
    });
});

// endpoint for fetching technologies
app.MapGet("/technologies", () =>
{
    return technologies.Select(t => new TechnologyDTO
    {
        Id = t.Id,
        Price = t.Price,
        Package = t.Package
    });
});

// endpoint for fetching interiors
app.MapGet("/interiors", () => 
{
    return interiors.Select(i => new InteriorDTO
    {
        Id = i.Id,
        Price = i.Price,
        Material = i.Material
    });
});

// endpoint for fetching paintcolors
app.MapGet("/paintcolors", () => 
{
    return paintColors.Select(pc => new PaintColorDTO
    {
        Id = pc.Id,
        Price = pc.Price,
        Color = pc.Color
    });
});

// endpoint for fetching orders
app.MapGet("/orders", () => 
{
    return orders.Select(o => new OrderDTO
    {
        Id = o.Id,
        Timestamp = o.Timestamp,
        WheelsId = o.WheelsId,
        Wheels = new WheelsDTO
        {
            Id = wheels[o.WheelsId - 1].Id,
            Price = wheels[o.WheelsId - 1].Price,
            Style = wheels[o.WheelsId - 1].Style
        },
        TechnologyId = o.TechnologyId,
        Technology = new TechnologyDTO
        {
            Id = technologies[o.TechnologyId - 1].Id,
            Price = technologies[o.TechnologyId - 1].Price,
            Package = technologies[o.TechnologyId - 1].Package

        },
        PaintColorId = o.PaintColorId,
        PaintColor = new PaintColorDTO
        {
            Id = paintColors[o.PaintColorId - 1].Id,
            Price = paintColors[o.PaintColorId - 1].Price,
            Color = paintColors[o.PaintColorId - 1].Color
        },
        InteriorId = o.InteriorId,
        Interior = new InteriorDTO
        {
            Id = interiors[o.InteriorId - 1].Id,
            Price = interiors[o.InteriorId - 1].Price,
            Material = interiors[o.InteriorId - 1].Material
        }
    });
});


//////////////////////////////////////
app.Run();

