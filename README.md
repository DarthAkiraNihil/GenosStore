# Genos Store

A simple course project that represents the system of the store of computer technics

Almost done but need to add some little functions

## Deployment

Needs docker and docker-compose installed

### Only schema
```shell
docker-compose up -d
docker cp ./cschema_compressed.sql <container_id>:/.cschema_compressed.sql
docker exec -i <container_id> psql -U postgres -d genos_store -f ./cschema_compressed.sql
```

### Schema and data
```shell
docker-compose up -d
docker cp ./cschema_compressed.sql <container_id>:/.dump.sql
docker exec -i <container_id> psql -U postgres -d genos_store -f ./dump.sql
```

### Test accounts:
#### Admin
Username: amogus@amogus.net
Password: p3n1s_Mus1C
#### Customer (individual)
Username: tjr@te.org
Password: String6!