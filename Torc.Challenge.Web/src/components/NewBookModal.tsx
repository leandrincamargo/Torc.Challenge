import React, { useState } from 'react';
import {
  Dialog,
  DialogTitle,
  DialogContent,
  TextField,
  DialogActions,
  Button,
} from '@mui/material';
import { Book } from './types/Books.types';
import api from '../services/api';

interface EditBookModalProps {
  open: boolean;
  book: Book;
  setNewBook: React.Dispatch<React.SetStateAction<boolean>>;
  setLoading: React.Dispatch<React.SetStateAction<boolean>>;
  onSearchBooks: () => Promise<void>;
}

const NewBookModal: React.FC<EditBookModalProps> = ({
  open,
  book,
  setNewBook,
  setLoading,
  onSearchBooks,
}) => {
  const [editedBook, setEditedBook] = useState<Book>(book);

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    setEditedBook((prevBook) => ({ ...prevBook, [name]: value }));
  };

  const handleSave = async () => {
    setLoading(true);
    await api.post(`/api/books/`, editedBook);
    setLoading(false);
    await onSearchBooks();
    setNewBook(false);
  };

  const onClose = () => {
    setNewBook(false);
  };

  return (
    <Dialog open={open} onClose={onClose}>
      <DialogTitle>New Book</DialogTitle>
      <DialogContent>
        <TextField
          autoFocus
          margin="dense"
          name="title"
          label="Title"
          type="text"
          fullWidth
          value={editedBook?.title || ''}
          onChange={handleChange}
        />
        <TextField
          autoFocus
          margin="dense"
          name="firstName"
          label="First Name"
          type="text"
          fullWidth
          value={editedBook?.firstName || ''}
          onChange={handleChange}
        />
        <TextField
          autoFocus
          margin="dense"
          name="lastName"
          label="Last Name"
          type="text"
          fullWidth
          value={editedBook?.lastName || ''}
          onChange={handleChange}
        />
        <TextField
          autoFocus
          margin="dense"
          name="totalCopies"
          label="Total Of Copies"
          type="number"
          fullWidth
          value={editedBook?.totalCopies || 0}
          onChange={handleChange}
        />
        <TextField
          autoFocus
          margin="dense"
          name="copiesInUse"
          label="Copies In Use"
          type="number"
          fullWidth
          value={editedBook?.copiesInUse || 0}
          onChange={handleChange}
        />
        <TextField
          autoFocus
          margin="dense"
          name="type"
          label="Type"
          type="text"
          fullWidth
          value={editedBook?.type || ''}
          onChange={handleChange}
        />
        <TextField
          autoFocus
          margin="dense"
          name="isbn"
          label="ISBN"
          type="text"
          fullWidth
          value={editedBook?.isbn || ''}
          onChange={handleChange}
        />
        <TextField
          autoFocus
          margin="dense"
          name="category"
          label="Category"
          type="text"
          fullWidth
          value={editedBook?.category || ''}
          onChange={handleChange}
        />
      </DialogContent>
      <DialogActions>
        <Button onClick={onClose} color="primary">
          Cancel
        </Button>
        <Button onClick={handleSave} color="primary">
          Save
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default NewBookModal;
