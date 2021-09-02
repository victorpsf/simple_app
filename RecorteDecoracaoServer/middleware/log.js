export default function (request, response, next) {
  console.log(`url: ${request.url}\nmethod: ${request.method}\n\n`);
  next();
}