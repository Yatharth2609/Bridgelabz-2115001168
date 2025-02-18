using System;
using System.Collections.Generic;
using System.Linq;

public abstract class JobRole
{
    public string Title { get; set; }
    public List<string> RequiredSkills { get; set; } = new List<string>();
    public int MinimumYearsExperience { get; set; }
    public abstract bool EvaluateSpecializedCriteria(Resume<JobRole> resume);
}

public class SoftwareEngineer : JobRole
{
    public List<string> ProgrammingLanguages { get; set; } = new List<string>();
    public bool HasOpenSourceContributions { get; set; }
    
    public override bool EvaluateSpecializedCriteria(Resume<JobRole> resume)
    {
        var candidateLanguages = resume.Skills.Where(s => 
            ProgrammingLanguages.Any(pl => s.ToLower().Contains(pl.ToLower()))).Count();
        
        return candidateLanguages >= 2 && (resume.YearsOfExperience >= 3 || HasOpenSourceContributions);
    }
}

public class DataScientist : JobRole
{
    public bool RequiresAdvancedDegree { get; set; }
    public List<string> SpecializedTools { get; set; } = new List<string>();
    
    public override bool EvaluateSpecializedCriteria(Resume<JobRole> resume)
    {
        bool hasRequiredEducation = !RequiresAdvancedDegree || resume.HasAdvancedDegree;
        var toolsKnown = resume.Skills.Where(s => 
            SpecializedTools.Any(t => s.ToLower().Contains(t.ToLower()))).Count();
        
        return hasRequiredEducation && toolsKnown >= Math.Min(2, SpecializedTools.Count);
    }
}

public class MarketingSpecialist : JobRole
{
    public bool RequiresDigitalExperience { get; set; }
    public List<string> MarketingPlatforms { get; set; } = new List<string>();
    
    public override bool EvaluateSpecializedCriteria(Resume<JobRole> resume)
    {
        bool hasDigitalExperience = !RequiresDigitalExperience || 
            resume.Skills.Any(s => s.ToLower().Contains("digital") || s.ToLower().Contains("online"));
        
        var platformsKnown = resume.Skills.Where(s => 
            MarketingPlatforms.Any(p => s.ToLower().Contains(p.ToLower()))).Count();
        
        return hasDigitalExperience && platformsKnown >= 1;
    }
}

public class Resume<T> where T : JobRole
{
    public string CandidateName { get; set; }
    public string Email { get; set; }
    public List<string> Skills { get; set; } = new List<string>();
    public int YearsOfExperience { get; set; }
    public bool HasAdvancedDegree { get; set; }
    public List<string> PreviousRoles { get; set; } = new List<string>();
    public bool HasPassedAiScreening { get; set; }
}

public class ResumeScreener<T> where T : JobRole
{
    private T _jobRole;
    
    public ResumeScreener(T jobRole)
    {
        _jobRole = jobRole;
    }
    
    public List<Resume<T>> ScreenResumes(List<Resume<T>> resumes)
    {
        List<Resume<T>> qualifiedCandidates = new List<Resume<T>>();
        
        foreach (var resume in resumes)
        {
            if (IsQualified(resume))
            {
                resume.HasPassedAiScreening = true;
                qualifiedCandidates.Add(resume);
            }
        }
        
        return qualifiedCandidates;
    }
    
    private bool IsQualified(Resume<T> resume)
    {
        // Check minimum years experience
        if (resume.YearsOfExperience < _jobRole.MinimumYearsExperience)
        {
            return false;
        }
        
        // Check required skills
        foreach (var skill in _jobRole.RequiredSkills)
        {
            if (!resume.Skills.Any(s => s.ToLower().Contains(skill.ToLower())))
            {
                return false;
            }
        }
        
        // Check job-specific criteria
        var baseResume = new Resume<JobRole>
        {
            CandidateName = resume.CandidateName,
            Email = resume.Email,
            Skills = resume.Skills,
            YearsOfExperience = resume.YearsOfExperience,
            HasAdvancedDegree = resume.HasAdvancedDegree,
            PreviousRoles = resume.PreviousRoles
        };
        
        return _jobRole.EvaluateSpecializedCriteria(baseResume);
    }
}

public class HiringSystem
{
    public void ProcessApplicationsForMultipleRoles<T>(List<Resume<T>> resumes, List<T> openPositions) where T : JobRole
    {
        Dictionary<string, List<Resume<T>>> qualifiedCandidatesByRole = new Dictionary<string, List<Resume<T>>>();
        
        foreach (var position in openPositions)
        {
            var screener = new ResumeScreener<T>(position);
            var qualifiedForRole = screener.ScreenResumes(resumes);
            qualifiedCandidatesByRole[position.Title] = qualifiedForRole;
        }
        
        // Print results
        foreach (var entry in qualifiedCandidatesByRole)
        {
            Console.WriteLine($"Qualified candidates for {entry.Key}: {entry.Value.Count}");
            foreach (var candidate in entry.Value)
            {
                Console.WriteLine($"  - {candidate.CandidateName} ({candidate.Email})");
            }
        }
    }
}

public class ResumeFactory
{
    public static Resume<T> CreateBasicResume<T>(string name, List<string> skills, int experience) where T : JobRole, new()
    {
        return new Resume<T>
        {
            CandidateName = name,
            Skills = skills,
            YearsOfExperience = experience,
            Email = $"{name.ToLower().Replace(" ", ".")}@example.com",
            HasPassedAiScreening = false
        };
    }
}

class Program
{
    static void Main()
    {
        // Define job roles
        var softwareRole = new SoftwareEngineer
        {
            Title = "Senior Software Engineer",
            RequiredSkills = new List<string> { "C#", "ASP.NET", "SQL" },
            MinimumYearsExperience = 5,
            ProgrammingLanguages = new List<string> { "C#", "JavaScript", "Python" },
            HasOpenSourceContributions = true
        };
        
        var dataRole = new DataScientist
        {
            Title = "Senior Data Scientist",
            RequiredSkills = new List<string> { "Python", "Machine Learning", "Statistics" },
            MinimumYearsExperience = 4,
            RequiresAdvancedDegree = true,
            SpecializedTools = new List<string> { "TensorFlow", "PyTorch", "R" }
        };
        
        // Create resumes for software engineers
        var seResumes = new List<Resume<SoftwareEngineer>>
        {
            ResumeFactory.CreateBasicResume<SoftwareEngineer>(
                "Yatharth Mishra", 
                new List<string> { "C#", "ASP.NET", "SQL", "JavaScript", "React" }, 
                7),
            
            ResumeFactory.CreateBasicResume<SoftwareEngineer>(
                "Priya Singh", 
                new List<string> { "Java", "Spring", "MongoDB", "Docker" }, 
                5),
                
            ResumeFactory.CreateBasicResume<SoftwareEngineer>(
                "Harshit Jain", 
                new List<string> { "C#", "WPF", "Entity Framework", "SQL Server" }, 
                3)
        };
        
        seResumes[0].HasAdvancedDegree = false;
        seResumes[1].HasAdvancedDegree = true;
        seResumes[2].HasAdvancedDegree = false;
        
        // Create resumes for data scientists
        var dsResumes = new List<Resume<DataScientist>>
        {
            ResumeFactory.CreateBasicResume<DataScientist>(
                "Divyanshu", 
                new List<string> { "Python", "TensorFlow", "Machine Learning", "Statistics", "SQL" }, 
                4),
                
            ResumeFactory.CreateBasicResume<DataScientist>(
                "Naman Mathur", 
                new List<string> { "R", "Statistics", "Machine Learning", "Data Visualization" }, 
                6),
                
            ResumeFactory.CreateBasicResume<DataScientist>(
                "Ranveer Singh", 
                new List<string> { "Python", "PyTorch", "Deep Learning", "NLP" }, 
                3)
        };
        
        dsResumes[0].HasAdvancedDegree = true;
        dsResumes[1].HasAdvancedDegree = true;
        dsResumes[2].HasAdvancedDegree = false;
        
        // Screen resumes
        var seScreener = new ResumeScreener<SoftwareEngineer>(softwareRole);
        var qualifiedSE = seScreener.ScreenResumes(seResumes);
        
        var dsScreener = new ResumeScreener<DataScientist>(dataRole);
        var qualifiedDS = dsScreener.ScreenResumes(dsResumes);
        
        // Print results
        Console.WriteLine($"Qualified Software Engineers: {qualifiedSE.Count}");
        foreach (var candidate in qualifiedSE)
        {
            Console.WriteLine($"  - {candidate.CandidateName}");
        }
        
        Console.WriteLine($"\nQualified Data Scientists: {qualifiedDS.Count}");
        foreach (var candidate in qualifiedDS)
        {
            Console.WriteLine($"  - {candidate.CandidateName}");
        }
        
        // Multi-role example with marketing specialists
        var marketingRole1 = new MarketingSpecialist
        {
            Title = "Digital Marketing Manager",
            RequiredSkills = new List<string> { "SEO", "Social Media", "Content Marketing" },
            MinimumYearsExperience = 3,
            RequiresDigitalExperience = true,
            MarketingPlatforms = new List<string> { "Google Ads", "Facebook", "Instagram" }
        };
        
        var marketingRole2 = new MarketingSpecialist
        {
            Title = "Brand Marketing Specialist",
            RequiredSkills = new List<string> { "Branding", "Campaign Management" },
            MinimumYearsExperience = 2,
            RequiresDigitalExperience = false,
            MarketingPlatforms = new List<string> { "Canva", "Adobe Creative Suite" }
        };
        
        var marketingResumes = new List<Resume<MarketingSpecialist>>
        {
            ResumeFactory.CreateBasicResume<MarketingSpecialist>(
                "Ram Sharma", 
                new List<string> { "SEO", "PPC", "Google Ads", "Social Media", "Digital Marketing" }, 
                4),
                
            ResumeFactory.CreateBasicResume<MarketingSpecialist>(
                "Harshita Singh", 
                new List<string> { "Branding", "Creative Direction", "Campaign Management", "Adobe Creative Suite" }, 
                5),
                
            ResumeFactory.CreateBasicResume<MarketingSpecialist>(
                "Surya Yadav", 
                new List<string> { "Content Marketing", "Social Media", "Influencer Relations", "Instagram" }, 
                2)
        };
        
        var marketingPositions = new List<MarketingSpecialist> { marketingRole1, marketingRole2 };
        
        var hiringSystem = new HiringSystem();
        Console.WriteLine("\nProcessing Marketing Applications:");
        hiringSystem.ProcessApplicationsForMultipleRoles(marketingResumes, marketingPositions);
    }
}