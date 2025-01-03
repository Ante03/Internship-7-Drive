using Internship_7_Drive.Data.Entities;
using Internship_7_Drive.Data.Entities.Models;
using Internship_7_Drive.Domain.Enums;

namespace Internship_7_Drive.Domain.Repositories
{
    public class CommentRepository : BaseRepository
    {
        public CommentRepository(DriveDbContext dbContext) : base(dbContext) { }

        public void DisplayComments(int fileId, int ownerId)
        {   
            while (true)
            {
                Console.Clear();
                var comments = GetAllCommentsForFile(fileId);
                Console.WriteLine("\nKomentari za datoteku:");
                foreach (var comment in comments)
                    Console.WriteLine($"ID: {comment.Id} | Sadrzaj: {comment.Content}");

                Console.WriteLine("\nUnesite naredbu ('dodaj komentar', 'uredi komentar', 'izbriši komentar', 'exit'): ");
                var commentCommand = Console.ReadLine();

                if (commentCommand?.Equals("exit", StringComparison.OrdinalIgnoreCase) == true)
                    break;

                if (commentCommand?.Equals("dodaj komentar", StringComparison.OrdinalIgnoreCase) == true)
                {
                    Console.Write("Unesite sadržaj komentara: ");
                    var content = Console.ReadLine();
                    AddComment(fileId, ownerId, content!);
                }
                else if (commentCommand?.Equals("uredi komentar", StringComparison.OrdinalIgnoreCase) == true)
                {
                    Console.Write("Unesite ID komentara za uređivanje: ");
                    if (int.TryParse(Console.ReadLine(), out var commentId))
                    {
                        Console.Write("Unesite novi sadržaj komentara: ");
                        var newContent = Console.ReadLine();
                        EditComment(commentId, newContent!, ownerId);
                    }
                    else
                        Console.WriteLine("Pogrešan ID komentara.");

                }
                else if (commentCommand?.Equals("izbrisi komentar", StringComparison.OrdinalIgnoreCase) == true)
                {
                    Console.Write("Unesite ID komentara za brisanje: ");
                    if (int.TryParse(Console.ReadLine(), out var commentId))
                        DeleteComment(commentId, ownerId);
                    else
                        Console.WriteLine("Pogrešan ID komentara.");
                }
                else
                    Console.WriteLine("Nepoznata naredba. Pokušajte ponovno.");
            }
        }

        public ResponseResultType AddComment(int fileId, int userId, string content)
        {
            var comment = new Comments
            {
                FileId = fileId,
                OwnerId = userId,
                Content = content,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };

            DbContext.Comments.Add(comment);
            SaveChanges();
            return ResponseResultType.Success;
        }

        public ResponseResultType EditComment(int commentId, string newContent, int ownerId)
        {
            var comment = DbContext.Comments.FirstOrDefault(c => c.Id == commentId);
            if (comment == null)
                return ResponseResultType.NotFound;

            if (ownerId != comment.OwnerId)
                return ResponseResultType.ValidationError;

            comment.Content = newContent;
            comment.UpdatedAt = DateTimeOffset.UtcNow;
            SaveChanges();
            return ResponseResultType.Success;
        }

        public ResponseResultType DeleteComment(int commentId, int ownerId)
        {
            var comment = DbContext.Comments.FirstOrDefault(c => c.Id == commentId);
            if (comment == null)
                return ResponseResultType.NotFound;

            if (ownerId != comment.OwnerId)
                return ResponseResultType.ValidationError;

                DbContext.Comments.Remove(comment);
            SaveChanges();
            return ResponseResultType.Success;
        }

        public List<Comments> GetAllCommentsForFile(int fileId)
        {
            return DbContext.Comments
                .Where(c => c.FileId == fileId)
                .OrderBy(c => c.CreatedAt)
                .ToList();
        }
    }
}
