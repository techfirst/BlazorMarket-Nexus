# Nexus - Modern Blazor SaaS Landing Page Template

A professional, conversion-focused landing page template built with **Blazor Server** and **Tailwind CSS**. Perfect for SaaS startups, fintech companies, and modern web applications.

![Blazor](https://img.shields.io/badge/Blazor-512BD4?style=for-the-badge&logo=blazor&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![Tailwind CSS](https://img.shields.io/badge/Tailwind_CSS-38B2AC?style=for-the-badge&logo=tailwind-css&logoColor=white)

## ✨ Features

### 📄 **Complete Landing Page Sections**
- **Hero Section** - Eye-catching hero with CTA buttons and mobile mockup
- **Trusted By** - Company logos and social proof
- **Features** - Highlight key product features with icons
- **Process Steps** - How it works section with numbered steps  
- **Integrations** - Showcase third-party integrations
- **Testimonials** - Customer reviews and social proof
- **Pricing** - Professional pricing tables with alignment
- **FAQ** - Expandable frequently asked questions
- **Blog Preview** - Latest blog posts showcase
- **Contact** - Contact form and information
- **CTA Section** - Final call-to-action before footer

### 📝 **Blog System**
- **Blog Listing Page** - Clean, responsive blog post grid
- **Blog Detail Pages** - Full article pages with related posts
- **Dynamic Content** - Sample blog posts with categories
- **SEO-Friendly** - Proper meta tags and structure

### 🎨 **Modern Design**
- **Responsive Design** - Mobile-first approach, works on all devices
- **Clean Typography** - Inter font for professional appearance
- **Smooth Animations** - CSS transitions and hover effects
- **Brand Colors** - Customizable color scheme (Nexus Blue theme)

### ⚡ **Interactive Features**
- **Smooth Scrolling** - Hash navigation with smooth scroll to sections
- **Scroll to Top Widget** - Floating button that appears on scroll
- **Mobile Navigation** - Hamburger menu for mobile devices
- **Interactive Components** - Blazor Server components with real-time updates

### 🛠️ **Technical Excellence**
- **.NET 8** - Latest .NET framework with modern C# features
- **Blazor Server** - Server-side rendering with SignalR real-time updates
- **Tailwind CSS** - Utility-first CSS framework via CDN
- **Component Architecture** - Modular, reusable Blazor components
- **Code-Behind Pattern** - Clean separation with `.razor.cs` files
- **Type Safety** - Full C# type checking and IntelliSense support

## 🚀 Quick Start

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- Any code editor (Visual Studio, VS Code, Rider)

### Installation

1. **Clone or download** the template
```bash
# If using git
git clone https://github.com/techfirst/BlazorMarket-Nexus.git
cd nexus

# Or extract the ZIP file and navigate to the folder
```

2. **Navigate to the project directory**
```bash
cd src/Nexus
```

3. **Restore dependencies**
```bash
dotnet restore
```

4. **Run the application**
```bash
# Development mode with hot reload
dotnet watch run

# Or standard run
dotnet run
```

5. **Open in browser**
   - Navigate to `https://localhost:7048` or `http://localhost:5048`
   - The template will be running with all features enabled

## 🎯 How to Customize

### 1. **Branding & Colors**
Edit `src/Nexus/Components/App.razor` to customize the Tailwind color scheme:
```javascript
colors: {
    'nexus-blue': '#659BFF',          // Primary blue
    'nexus-blue-dark': '#4686FE',     // Darker blue for hovers
    'nexus-blue-light': '#E6F1FF',    // Light blue backgrounds
    'nexus-gray': '#FAFBFC',          // Light gray backgrounds
    'nexus-dark': '#0F172A',          // Dark text color
}
```

### 2. **Content Updates**
- **Hero Section**: Edit `src/Nexus/Components/Sections/HeroSection.razor`
- **Features**: Update `src/Nexus/Components/Sections/FeaturesSection.razor`
- **Pricing**: Modify `src/Nexus/Components/Sections/PricingSection.razor`
- **Contact Info**: Update `src/Nexus/Components/Sections/ContactSection.razor`

### 3. **Images & Assets**
- Replace logo and branding in `src/Nexus/wwwroot/images/`
- Update favicon: Replace `src/Nexus/wwwroot/favicon.png`
- Phone mockup: Replace `src/Nexus/wwwroot/images/phone2.png`

### 4. **Navigation & Routing**
- Main navigation: `src/Nexus/Components/Layout/NavMenu.razor`
- Add new pages: Create in `src/Nexus/Components/Pages/`
- Update routing: Modify page `@page` directives

### 5. **Blog Content**
- Blog posts: Edit sample data in `src/Nexus/Services/BlogService.cs`
- Add real blog functionality by connecting to a CMS or database
- Customize blog layout: `src/Nexus/Components/Pages/Blog.razor` and `src/Nexus/Components/Pages/BlogDetail.razor`

## 📁 Project Structure

```
nexus/
├── Nexus.sln           # Solution file
├── LICENSE             # License file
├── README.md           # This file
└── src/
    └── Nexus/          # Main project folder
        ├── Components/
        │   ├── Layout/      # Layout components (NavMenu, MainLayout)
        │   ├── Pages/       # Routable page components
        │   ├── Sections/    # Landing page sections
        │   ├── Shared/      # Reusable UI components
        │   └── App.razor    # Root application component
        ├── Models/          # Data models and DTOs
        ├── Services/        # Business logic services
        ├── wwwroot/         # Static assets (CSS, images, etc.)
        ├── Program.cs       # Application configuration
        ├── appsettings.json # App configuration
        └── Nexus.csproj     # Project file
```

## 🔧 Development Commands

```bash
# Navigate to project directory first
cd src/Nexus

# Build the project
dotnet build

# Run with hot reload (recommended for development)
dotnet watch run

# Run without hot reload
dotnet run

# Format code
dotnet format

# Add NuGet packages
dotnet add package [PackageName]
```

## 📱 Responsive Breakpoints

- **Mobile**: < 768px
- **Tablet**: 768px - 1023px  
- **Desktop**: 1024px+

All components are built mobile-first and scale up responsively.

## 🎨 Styling Architecture

- **Tailwind CSS**: Utility-first CSS framework loaded via CDN
- **Component Scoping**: Use `.razor.css` files for component-specific styles
- **Custom Properties**: Tailwind config in `App.razor` for brand colors
- **Responsive Design**: All components built with mobile-first approach

## 🚀 Deployment

### Development
```bash
cd src/Nexus
dotnet run --environment Development
```

### Production
```bash
cd src/Nexus
dotnet run --environment Production
```

The template is ready for deployment to:
- **Azure App Service**
- **IIS**
- **Docker containers**
- **Any .NET 8 compatible hosting**

## 📋 Browser Support

- **Chrome** (latest)
- **Firefox** (latest)
- **Safari** (latest)
- **Edge** (latest)
- **Mobile browsers** (iOS Safari, Chrome Mobile)

## 🤝 Support

This template includes:
- ✅ Complete source code
- ✅ All assets and images
- ✅ Documentation
- ✅ Commercial usage rights

For questions or customization needs, refer to the documentation or modify the code to fit your requirements.

## 📄 License

This template is licensed under a Commercial Use License. See [LICENSE](LICENSE) for details.

- ✅ Use for unlimited commercial projects
- ✅ Modify and customize freely  
- ✅ No attribution required
- ❌ Cannot resell or redistribute the template

---

**Built with ❤️ using Blazor Server and Tailwind CSS**
