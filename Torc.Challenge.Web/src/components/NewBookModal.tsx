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
  setBook: React.Dispatch<React.SetStateAction<Book>>;
  setOpenModal: React.Dispatch<React.SetStateAction<boolean>>;
  setLoading: React.Dispatch<React.SetStateAction<boolean>>;
  onSearchBooks: (newPage: number, newRowsPerPage: number) => Promise<void>;
}

const NewBookModal: React.FC<EditBookModalProps> = ({
  open,
  book,
  setBook,
  setOpenModal,
  setLoading,
  onSearchBooks,
}) => {
  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    setBook((prevBook) => ({ ...prevBook, [name]: value }));
  };

  const onSave = async () => {
    setLoading(true);
    if (book.bookId > 0) {
      try {
        await api.put(`/api/books/${book.bookId}`, book);
      } catch (e) {
        console.error(e);
      }
    } else {
      try {
        await api.post(`/api/books/`, book);
      } catch (e) {
        console.error(e);
      }
    }
    setLoading(false);
    onSearchBooks(-1, -1);
    setOpenModal(false);
  };

  const onClose = () => {
    setOpenModal(false);
  };

  return (
    <Dialog open={open} onClose={onClose} style={{ zIndex: 100 }}>
      <DialogTitle>New Book</DialogTitle>
      <DialogContent>
        <TextField
          autoFocus
          margin="dense"
          name="title"
          label="Title"
          type="text"
          fullWidth
          value={book?.title || ''}
          onChange={handleChange}
          disabled={book.bookId > 0}
        />
        <TextField
          autoFocus
          margin="dense"
          name="firstName"
          label="First Name"
          type="text"
          fullWidth
          value={book?.firstName || ''}
          onChange={handleChange}
          disabled={book.bookId > 0}
        />
        <TextField
          autoFocus
          margin="dense"
          name="lastName"
          label="Last Name"
          type="text"
          fullWidth
          value={book?.lastName || ''}
          onChange={handleChange}
          disabled={book.bookId > 0}
        />
        <TextField
          autoFocus
          margin="dense"
          name="totalCopies"
          label="Total Of Copies"
          type="number"
          fullWidth
          value={book?.totalCopies || 0}
          onChange={handleChange}
        />
        <TextField
          autoFocus
          margin="dense"
          name="copiesInUse"
          label="Copies In Use"
          type="number"
          fullWidth
          value={book?.copiesInUse || 0}
          onChange={handleChange}
        />
        <TextField
          autoFocus
          margin="dense"
          name="type"
          label="Type"
          type="text"
          fullWidth
          value={book?.type || ''}
          onChange={handleChange}
        />
        <TextField
          autoFocus
          margin="dense"
          name="isbn"
          label="ISBN"
          type="text"
          fullWidth
          value={book?.isbn || ''}
          onChange={handleChange}
          disabled={book.bookId > 0}
        />
        <TextField
          autoFocus
          margin="dense"
          name="category"
          label="Category"
          type="text"
          fullWidth
          value={book?.category || ''}
          onChange={handleChange}
        />
      </DialogContent>
      <DialogActions>
        <Button onClick={onClose} color="primary">
          Cancel
        </Button>
        <Button onClick={onSave} color="primary">
          Save
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default NewBookModal;
