from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware
from fastapi.openapi.utils import get_openapi
from fastapi.routing import APIRoute

from app.routers import general

app = FastAPI()

app.include_router(general.router)

origins = ["*"]

app.add_middleware(CORSMiddleware,
                   allow_origins=origins,
                   allow_credentials=True,
                   allow_methods=["*"],
                   allow_headers=["*"])


def custom_openapi():  # pragma: no coverage
    if app.openapi_schema:
        return app.openapi_schema

    openapi_schema = get_openapi(
        title="F1 23 Competition",
        version="0.0.1",
        description="An API to create a time-trial style competition for F1 23 race simulators.",
        license_info={
            "name": "MIT",
            "url": "https://github.com/niek-o/f1-23-competition"
        },
        routes=app.routes,
    )

    openapi_schema["info"]["x-logo"] = {
        "url": "https://upload.wikimedia.org/wikipedia/commons/f/f2/New_era_F1_logo.png"
    }

    app.openapi_schema = openapi_schema

    return app.openapi_schema


def function_name_as_operation_id(fast_api: FastAPI):
    for route in fast_api.routes:
        if isinstance(route, APIRoute):
            route.operation_id = route.name


function_name_as_operation_id(app)

app.openapi = custom_openapi
