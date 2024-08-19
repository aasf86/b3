FROM node as node
WORKDIR /app
EXPOSE 80

COPY src/B3.App/ .
RUN npm install
RUN npm run build

FROM nginx
COPY --from=node /app/dist/b3.app/browser /usr/share/nginx/html
COPY src/B3.App/nginx.conf /etc/nginx/nginx.conf
COPY src/B3.App/mime.types /etc/nginx/mime.types
