
export function fixUrl(url: string) {
  if (!/^https?:\/\//i.test(url)) {
    url = 'http://' + url;
  }
  return url;
}
