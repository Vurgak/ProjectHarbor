import { FormEvent, useState } from 'react';
import { Input } from '@/components/ui/input';

type SearchBarProps = {
  disabled: boolean
  onSearch: (text: string) => void
}

export default function SearchBar({ disabled, onSearch }: SearchBarProps) {
  const [text, setText] = useState('');

  const handleSubmit = (event: FormEvent) => {
    onSearch(text)
  }

  return (
    <Input type="text" value={text} onChange={event => setText(event.target.value)} disabled={disabled} />
  )
}
