using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class ExceptionMessages
{
    public const string DataAlreadyInitializedException = "Data is already initialized!";
    public const string DataNotInitializedException = "Data is not initialized!";
    public const string InexistingCourseInDataBase = "The course you are trying to get does not exist in the data base!";
    public const string InexistingStudentInDataBase = "The user name for the student you are trying to get does not exist!";
  
    public const string UnauthorizedAccessExceptionMessage = "The folder/file you are trying to get access needs a higher level of rights than you currently have.";
    public const string ComparisonOfFilesWithDifferentSizes = "Files not of equal size, certain mismatch.";
   
    public const string UnableToGoHigherInPartitionHierarchy = "You've already accessed the highest directory in Partition Hierarchy!";
    public const string UnableToParseNumber = "The sequence you've written is not a valid number.";
    public const string InvalidStudentFilter = "The given filter is not one of the following: excellent/average/poor";
    public const string InvalidComparisonQuery = "The comparison query you want, does not exist in the context of the current program!";
    public const string InvalidTakeCommand = "The take command expected does not match the format wanted!";
    public const string InvalidTakeQuantityParameter = "The takeQuantity expected does not match the format wanted!";
    public const string StudentAlreadyEnrolledInGivenCourse = "The {0} already exists in {1}.";
  
    public const string InvalidNumberOfScores = "The number of scores for the given course is greater than the possible";
    public const string InvalidScores = "The number for the score you've entered is not in the range of 0 - 100";
   
 
}

