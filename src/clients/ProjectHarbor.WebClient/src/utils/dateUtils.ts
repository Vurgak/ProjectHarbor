export function fromNow(date: Date) {
  const difference = Math.abs(Date.now() - new Date(date).getTime());

  const seconds = Math.floor(difference / 1000);
  const minutes = Math.floor(seconds / 60);
  const hours = Math.floor(minutes / 60);
  const days = Math.floor(hours / 24);

  if (days > 0)
    return `${days} days`
  else if (hours > 0)
    return `${hours} hours`
  else if (minutes > 0)
    return `${minutes} minutes`
  else
    return `${seconds} seconds`
}
