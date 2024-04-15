export interface Book {
  bookId: number;
  title: string;
  firstName: string;
  lastName: string;
  totalCopies: number;
  copiesInUse: number;
  type?: string | null;
  isbn?: string | null;
  category?: string | null;
}
